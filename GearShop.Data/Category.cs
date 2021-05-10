using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Data
{
    public enum CategoryType { Climbing, Hiking, Camping, Cycling, Running}
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Category:")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "Category Type:")]
        public CategoryType CategoryType { get; set; }

        public virtual List<Gear> GearInCategory { get; set; } = new List<Gear>();
    }
}
