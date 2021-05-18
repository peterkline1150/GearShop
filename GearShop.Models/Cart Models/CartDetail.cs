using GearShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Models.Cart_Models
{
    public class CartDetail
    {
        public int CartId { get; set; }

        [Display(Name = "User ID:")]
        public Guid UserId { get; set; }

        public virtual List<IndividualGear> GearInCart { get; set; } = new List<IndividualGear>();

        public decimal Subtotal { get; set; }

        public decimal TotalCost { get; set; }
    }
}
