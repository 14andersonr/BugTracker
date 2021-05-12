using BugTracker.Data;
using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Services
{
   public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(Comment model)// we call CreateComment from a controller
        {
            var entity = // local variable 
                new Comment() //eqialls to new Comment object.. where we save in the database (dbsetComments)
                {
                    Text = model.Text,
                    CommentId = model.CommentId, //thats given from postman
                    Content = model.Content,
                    OwnerId = _userId,
                    CreatedUtc = DateTimeOffset.Now,
                    ErrorId = model.ErrorId // that comes from Error wh
                };

            using (var ctx = new ApplicationDbContext()) // add it to the database 
            {
                ctx.Comments.Add(entity); // then save it 
                return ctx.SaveChanges() == 1; // the number of changes made in the database while it is saved
            }
        }
           
        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e => new CommentListItem
                        {
                            
                            Text = e.Text,
                            CommentId = e.CommentId,
                            ErrorId = e.ErrorId,
                            Content = e.Content,
                            CreatedUtc = e.CreatedUtc
                        }
                        );

                return query.ToArray();
            }
        }

        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.CommentId == id && e.OwnerId == _userId);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        Text = entity.Text,
                        ErrorId = entity.ErrorId,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc
                    };
             }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.CommentId == model.CommentId && e.OwnerId == _userId);
                entity.Content = model.content;                
                return ctx.SaveChanges() == 1;
   
            }
        }
            public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.CommentId == commentId && e.OwnerId == _userId);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
