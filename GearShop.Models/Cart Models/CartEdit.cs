using GearShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Models.Cart_Models
{
    public class CartEdit
    {
        [Key]
        public int CartId { get; set; }

        public Guid UserId { get; set; }

        public virtual List<IndividualGear> GearInCart { get; set; } = new List<IndividualGear>();
    }
}
