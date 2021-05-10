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

        [Required]
        public string GearNameInCart { get; set; }

        [Required]
        public int AmountOfGearInCart { get; set; }

        [Required]
        public decimal CostOfGear { get; set; }

        [Required]
        public int GearId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Cart))]
        public int CartId { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
