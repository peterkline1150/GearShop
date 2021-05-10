using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        [Display(Name = "User ID:")]
        public Guid UserId { get; set; }

        [Display(Name = "Comment:")]
        public string CommentText { get; set; }

        [ForeignKey(nameof(Gear))]
        public int GearId { get; set; }

        public virtual Gear Gear { get; set; }

        [Required]
        [Range(0,5)]
        [Display(Name = "User Rating:")]
        public int Rating { get; set; }

        public virtual List<Reply> Replies { get; set; }
    }
}
