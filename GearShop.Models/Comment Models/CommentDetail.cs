using GearShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Models.Comment_Models
{
    public class CommentDetail
    {
        public int CommentId { get; set; }

        [Required]
        [Display(Name = "User ID:")]
        public Guid UserId { get; set; }

        [Required]
        [Display(Name = "Title: ")]
        [MaxLength(50, ErrorMessage = "Title is too long.")]
        public string CommentTitle { get; set; }

        [Display(Name = "Comment:")]
        public string CommentText { get; set; }

        public virtual Gear Gear { get; set; }

        [Required]
        [Range(0, 5)]
        [Display(Name = "User Rating:")]
        public int Rating { get; set; }

        public virtual List<Reply> Replies { get; set; }
    }
}
