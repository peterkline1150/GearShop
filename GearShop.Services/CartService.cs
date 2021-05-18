using GearShop.Data;
using GearShop.Models;
using GearShop.Models.Cart_Models;
using GearShop.Models.IndividualGear_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GearShop.Services
{
    public class CartService
    {
        private readonly Guid _userId;

        public CartService (Guid userId)
        {
            _userId = userId;
        }

        public CartDetail ViewCart()
        {
            using (var ctx = new ApplicationDbContext())
            {
                DoesCartExist();

                var entity = ctx.Carts.Include(e => e.GearInCart).Single(e => e.UserId == _userId);

                return new CartDetail()
                {
                    CartId = entity.CartId,
                    GearInCart = entity.GearInCart,
                    TotalCost = entity.TotalCost,
                    Subtotal = entity.Subtotal,
                    UserId = entity.UserId
                };
            }
        }

        public bool AddGearToCart(GearDetail model)
        {
            DoesCartExist();

            using (var ctx = new ApplicationDbContext())
            {
                var cartUpdateEntity = ctx.Carts.Include(e => e.GearInCart).Single(e => e.UserId == _userId);
                var gearEntity = ctx.Gear.Find(model.GearId);

                int? gearIdToAddTo = 0;
                foreach (var gear in cartUpdateEntity.GearInCart)
                {
                    if (gear.GearId == model.GearId)
                    {
                        gearIdToAddTo = gear.GearId;
                    }
                }

                if (gearIdToAddTo == 0)
                {
                    var gearInCart = new IndividualGear()
                    {
                        AmountOfGearInCart = model.NumberOfGearInCart,
                        NameOfGear = model.Name,
                        Price = model.Price,
                        GearId = model.GearId,
                        CartId = cartUpdateEntity.CartId,
                        UserId = _userId
                    };

                    cartUpdateEntity.GearInCart.Add(gearInCart);
                    ctx.GearInCarts.Add(gearInCart);

                    gearEntity.NumAvailable -= model.NumberOfGearInCart;

                    return ctx.SaveChanges() >= 1;
                }
                else
                {
                    var gear = ctx.Gear.Find(model.GearId);
                    var gearAlreadyInCart = ctx.GearInCarts.Single(e => e.GearId == model.GearId && e.UserId == _userId);

                    gear.NumAvailable -= model.NumberOfGearInCart;
                    gearAlreadyInCart.AmountOfGearInCart += model.NumberOfGearInCart;

                    return ctx.SaveChanges() >= 1;
                }
            }
        }

        public bool UpdateCart(CartEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var cartUpdateEntity = ctx.Carts.Include(e => e.GearInCart).Single(e => e.CartId == model.CartId);

                cartUpdateEntity.CartId = model.CartId;
                cartUpdateEntity.UserId = model.UserId;

                var gearToHaveInCart = new List<IndividualGear>();
                var gearToRemoveFromCart = new List<IndividualGear>();

                foreach (var gear in model.GearInCart)
                {
                    if (gear.AmountOfGearInCart <= 0)
                    {
                        gearToRemoveFromCart.Add(gear);
                    }
                    else
                    {
                        gearToHaveInCart.Add(gear);
                    }
                }

                foreach (var gear in gearToRemoveFromCart)
                {
                    cartUpdateEntity.GearInCart.Remove(gear);
                    //ctx.GearInCarts.Remove(gear);
                }

                cartUpdateEntity.GearInCart = gearToHaveInCart;

                return ctx.SaveChanges() >= 1;
            }
        }

        public CartCheckout PurchaseCart()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var cartEntity = ctx.Carts.Include(e => e.GearInCart).Single(e => e.UserId == _userId);

                var model = new CartCheckout()
                {
                    Subtotal = cartEntity.Subtotal,
                    TotalCost = cartEntity.TotalCost
                };

                ctx.Carts.Remove(cartEntity);
                ctx.SaveChanges();

                return model;
            }
        }

        private void DoesCartExist()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var doesExist = false;
                foreach (var cart in ctx.Carts)
                {
                    if (cart.UserId == _userId)
                    {
                        doesExist = true;
                    }
                }

                if (!doesExist)
                {
                    var entity = new Cart()
                    {
                        UserId = _userId
                    };

                    ctx.Carts.Add(entity);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
