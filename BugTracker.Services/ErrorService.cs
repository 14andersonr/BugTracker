using BugTracker.Data;
using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Services
{
    public class ErrorService
    {
        private readonly Guid _userId;

        public ErrorService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateError(ErrorCreate model)
        {
            var entity =
                new Error()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Resolved = model.Resolved,
                    ProjectId = model.ProjectId,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Errors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ErrorListItem> GetErrors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Errors
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ErrorListItem
                                {
                                    ErrorId = e.ErrorId,
                                    Title = e.Title,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public ErrorDetail GetErrorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Errors
                        .Single(e => e.ErrorId == id && e.OwnerId == _userId);
                return
                    new ErrorDetail
                    {
                        ErrorId = entity.ErrorId,
                        Title = entity.Title,
                        Resolved = entity.Resolved,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateError(ErrorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Errors
                        .Single(e => e.ErrorId == model.ErrorId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Resolved = model.Resolved;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteError(int errorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Errors
                        .Single(e => e.ErrorId == errorId && e.OwnerId == _userId);

                ctx.Errors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
