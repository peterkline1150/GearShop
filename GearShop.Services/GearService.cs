using GearShop.Data;
using GearShop.Models;
using GearShop.Models.Gear_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Services
{
    public class GearService
    {
        public IEnumerable<GearListItem> GetGear()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Gear.Select(e => new GearListItem()
                {
                    GearId = e.GearId,
                    Name = e.Name,
                    Price = e.Price,
                    Category = e.Category,
                    Comments = e.Comments,
                    NumAvailable = e.NumAvailable
                });

                return query.ToArray();
            }
        }

        public bool CreateGear(GearCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new Gear()
                {
                    Name = model.Name,
                    Price = model.Price,
                    NumAvailable = model.NumAvailable,
                    CategoryId = model.CategoryId
                };

                ctx.Gear.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public GearDetail GetGearById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Gear.Find(id);

                return new GearDetail()
                {
                    GearId = entity.GearId,
                    Name = entity.Name,
                    Price = entity.Price,
                    NumAvailable = entity.NumAvailable,
                    Category = entity.Category,
                    Comments = entity.Comments
                };
            }
        }

        public bool UpdateGear(GearEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Gear.Find(model.GearId);

                entity.Name = model.Name;
                entity.Price = model.Price;
                entity.NumAvailable = model.NumAvailable;
                entity.CategoryId = model.CategoryId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGear(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Gear.Find(id);

                ctx.Gear.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
