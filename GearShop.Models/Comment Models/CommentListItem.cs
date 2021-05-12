using GearShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Models.Comment_Models
{
    public class CommentListItem
    {
        public int CommentId { get; set; }

        public Guid UserId { get; set; }

        [Display(Name = "Title:")]
        public string CommentTitle { get; set; }

        public virtual Gear Gear { get; set; }

        [Display(Name = "Rating:")]
        public int Rating { get; set; }
    }
}
