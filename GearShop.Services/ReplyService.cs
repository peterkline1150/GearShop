using GearShop.Data;
using GearShop.Models.Reply_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService (Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Replies.Where(e => e.UserId == _userId).Select(e => new ReplyListItem()
                {
                    ReplyId = e.ReplyId,
                    ReplyText = e.ReplyText,
                    UserId = e.UserId,
                    Comment = e.Comment
                });

                return query.ToArray();
            }
        }

        public bool CreateReply(ReplyCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new Reply()
                {
                    ReplyText = model.ReplyText,
                    CommentId = model.CommentId,
                    UserId = _userId
                };

                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ReplyDetail GetReplyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Replies.Single(e => e.ReplyId == id && e.UserId == _userId);

                return new ReplyDetail()
                {
                    ReplyId = entity.ReplyId,
                    ReplyText = entity.ReplyText,
                    Comment = entity.Comment,
                    UserId = entity.UserId
                };
            }
        }

        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Replies.Single(e => e.ReplyId == model.ReplyId && e.UserId == _userId);

                entity.ReplyText = model.ReplyText;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReply(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Replies.Single(e => e.ReplyId == id && e.UserId == _userId);
                ctx.Replies.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
