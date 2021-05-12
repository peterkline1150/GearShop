using GearShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Models.Category_Models
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public CategoryType CategoryType { get; set; }

        public virtual List<Gear> GearInCategory { get; set; } = new List<Gear>();
    }
}
