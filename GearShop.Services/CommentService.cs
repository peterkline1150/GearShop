using GearShop.Data;
using GearShop.Models.Comment_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService (Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment (CommentCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new Comment()
                {
                    UserId = _userId,
                    CommentTitle = model.Title,
                    CommentText = model.CommentText,
                    GearId = model.GearId,
                    Rating = model.Rating
                };

                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Comments.Where(e => e.UserId == _userId).Select(e => new CommentListItem()
                {
                    CommentId = e.CommentId,
                    UserId = e.UserId,
                    Gear = e.Gear,
                    Rating = e.Rating,
                    CommentTitle = e.CommentTitle
                });
                return query.ToArray();
            }
        }

        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments.Single(e => e.CommentId == id && e.UserId == _userId);

                return new CommentDetail()
                {
                    CommentId = entity.CommentId,
                    CommentText = entity.CommentText,
                    CommentTitle = entity.CommentTitle,
                    Gear = entity.Gear,
                    Rating = entity.Rating,
                    Replies = entity.Replies,
                    UserId = entity.UserId
                };
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments.Single(e => e.CommentId == model.CommentId && e.UserId == _userId);

                entity.CommentTitle = model.CommentTitle;
                entity.CommentText = model.CommentText;
                entity.Rating = model.Rating;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments.Single(e => e.CommentId == id && e.UserId == _userId);

                ctx.Comments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
