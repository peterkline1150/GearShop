using GearShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Models
{
    public class GearListItem
    {
        public int GearId { get; set; }

        public string Name { get; set; }

        [Display(Name = "This Gear is available on our site:")]
        public bool IsAvailable { get; }

        [Required]
        [Display(Name = "Price of item:")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

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
    }
}
