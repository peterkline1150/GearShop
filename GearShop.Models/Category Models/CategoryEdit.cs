using GearShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Models.Category_Models
{
    public class CategoryEdit
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public CategoryType CategoryType { get; set; }
    }
}
