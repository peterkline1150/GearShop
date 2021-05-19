using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Data
{
    public class IndividualGear
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(GearInCart))]
        public int? GearId { get; set; }

        public Gear GearInCart { get; set; }

        [Required]
        public int AmountOfGearInCart { get; set; }

        [Required]
        public string NameOfGear { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Cart))]
        public int? CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
