using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Models.Reply_Models
{
    public class ReplyEdit
    {
        [Key]
        public int ReplyId { get; set; }

        [Display(Name = "Reply:")]
        public string ReplyText { get; set; }
    }
}
