using GearShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Models
{
    public class GearDetail
    {
        public int GearId { get; set; }

        [Display(Name = "Name of Gear:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Number of pieces left:")]
        public int NumAvailable { get; set; }

        [Display(Name = "This Gear is available on our site:")]
        public bool IsAvailable
        {
            get
            {
                return NumAvailable > 0;
            }
        }

        [Required]
        [Display(Name = "Price of item:")]
        public decimal Price { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<Comment> Comments { get; set; } = new List<Comment>();

        [Display(Name = "Gear Rating:")]
        public double AverageRating
        {
            get
            {
                double rating = 0;

                foreach (var comment in Comments)
                {
                    rating += comment.Rating;
                }

                return Math.Round(rating / Comments.Count, 1);
            }
        }

        [Required]
        [Display(Name = "How many would you like to purchase?")]
        public int NumberOfGearInCart { get; set; }

        public string PictureUrl { get; set; }
    }
}
