using GearShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Models.Comment_Models
{
    public class CommentEdit
    {
        public int CommentId { get; set; }

        [Display(Name = "Title: ")]
        [MaxLength(50, ErrorMessage = "Title is too long.")]
        public string CommentTitle { get; set; }

        [Display(Name = "Comment:")]
        public string CommentText { get; set; }

        [Range(0, 5)]
        [Display(Name = "User Rating:")]
        public int Rating { get; set; }
    }
}
