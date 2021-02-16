using BugTracker.Data;
using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Services
{
    public class BuildErrorService
    {
        private readonly Guid _userId;

        public BuildErrorService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBuildError(BuildErrorCreate model)
        {
            var entity =
                new BuildError()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    LineNumber = model.LineNumber,
                    BuildErrorMessage = model.BuildErrorMessage,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.BuildErrors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BuildErrorListItem> GetBuildErrors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .BuildErrors
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new BuildErrorListItem
                        {
                            ErrorId = e.ErrorId,
                            Title = e.Title,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }

        public BuildErrorDetail GetBuildErrorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .BuildErrors
                    .Single(e => e.ErrorId == id && e.OwnerId == _userId);
                return
                    new BuildErrorDetail
                    {
                        ErrorId = entity.ErrorId,
                        LineNumber = entity.LineNumber,
                        BuildErrorMessage = entity.BuildErrorMessage,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc 
                    };
            }
        }

        public bool UpdateBuildError(BuildErrorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .BuildErrors
                    .Single(e => e.ErrorId == model.ErrorId && e.OwnerId == _userId);
                entity.Title = model.Title;
                entity.Resolved = model.Resolved;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBuildError(int errorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                .BuildErrors
                .Single(e => e.ErrorId == errorId && e.OwnerId == _userId);

                ctx.BuildErrors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
