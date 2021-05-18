using GearShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Models.Category_Models
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }

        [Display(Name = "Category:")]
        public string CategoryName { get; set; }

        public CategoryType CategoryType { get; set; }

        [Display(Name = "Related Gear:")]
        public virtual List<Gear> GearInCategory { get; set; } = new List<Gear>();
    }
}
