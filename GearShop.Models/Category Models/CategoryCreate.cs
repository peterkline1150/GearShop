using GearShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Models.Category_Models
{
    public class CategoryCreate
    {
        [Required]
        public string CategoryName { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }
    }
}
