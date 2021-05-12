using GearShop.Data;
using GearShop.Models;
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
                    CategoryId = e.CategoryId
                });

                return query.ToArray();
            }
        }
    }
}
