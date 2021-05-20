using GearShop.Data;
using GearShop.Models;
using GearShop.Models.Cart_Models;
using GearShop.Models.IndividualGear_Models;
using GearShop.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GearShop.WebMVC.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart/Index
        public ActionResult Index()
        {
            var service = CreateCartService();
            var model = service.ViewCart();
            return View(model);
        }

        // GET: Cart/Edit/
        public ActionResult Edit()
        {
            var service = CreateCartService();
            var detail = service.ViewCart();
            var model = new CartEdit()
            {
                CartId = detail.CartId,
                GearInCart = detail.GearInCart,
                UserId = detail.UserId
            };

            return View(model);
        }

        // POST: Cart/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CartEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCartService();

            if (service.UpdateCart(model))
            {
                TempData["SaveResult"] = "Cart Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "You cannot add that much gear to your cart");
            return View(model);
        }

        public ActionResult AddGearToCart()
        {
            GearDetail modelToAddToCart = (GearDetail)TempData["GearToAddToCart"];

            var service = CreateCartService();

            if (service.AddGearToCart(modelToAddToCart))
            {
                TempData["SaveResult"] = "Successfully added to your cart!";

                return RedirectToAction("Index");
            }

            TempData["SaveResult"] = "Was not able to add to your cart";
            return RedirectToAction("Index", "Category");
        }

        // GET: Cart/CheckOut
        public ActionResult CheckOut()
        {
            var service = CreateCartService();
            var model = service.PurchaseCart();
            return View(model);
        }

        private CartService CreateCartService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CartService(userId);
            return service;
        }
    }
}