using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Models.IndividualGear_Models
{
    public class IndividualGearCreate
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
    }
}
