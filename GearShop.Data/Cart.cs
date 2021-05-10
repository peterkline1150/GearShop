using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Data
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        [Display(Name = "User ID:")]
        public Guid UserId { get; set; }

        public virtual List<IndividualGear> GearInCart { get; set; } = new List<IndividualGear>();

        public decimal Subtotal { get 
            {
                decimal subtotal = 0;

                foreach (var gear in GearInCart)
                {
                    subtotal += gear.CostOfGear;
                }

                return Math.Round(subtotal, 2);
            }
        }

        public decimal TotalCost { get 
            {
                return Math.Round(Subtotal * 1.07m, 2);
            }
        }
    }
}
