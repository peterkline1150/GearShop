using GearShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Models.Reply_Models
{
    public class ReplyListItem
    {
        public int ReplyId { get; set; }

        public Guid UserId { get; set; }

        [Display(Name = "Reply:")]
        public string ReplyText { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
