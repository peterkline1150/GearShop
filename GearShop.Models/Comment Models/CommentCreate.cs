using GearShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Models.Comment_Models
{
    public class CommentCreate
    {
        [Required]
        [Display(Name = "Title: ")]
        [MaxLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; }

        [Display(Name = "User ID:")]
        public Guid UserId { get; set; }

        [Display(Name = "Comment:")]
        public string CommentText { get; set; }

        public int GearId { get; set; }

        [Required]
        [Range(0, 5)]
        [Display(Name = "User Rating:")]
        public int Rating { get; set; }
    }
}
