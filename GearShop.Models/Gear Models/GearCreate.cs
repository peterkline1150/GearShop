using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Models.Gear_Models
{
    public class GearCreate
    {
        [Required]
        [Display(Name = "Name of Gear:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Number of pieces left:")]
        public int NumAvailable { get; set; }

        [Required]
        [Display(Name = "Price of item:")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public string PictureUrl { get; set; }
    }
}
