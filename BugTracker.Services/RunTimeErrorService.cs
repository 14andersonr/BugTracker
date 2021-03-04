using BugTracker.Data;
using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Services
{
    public class RunTimeErrorService
    {
        private readonly Guid _userId;

        public RunTimeErrorService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRunTimeError(RunTimeErrorCreate model)
        {
            var entity =
                new RunTimeError()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    LineNumber = model.LineNumber,
                    RunTimeMessage = model.RunTimeMessage,
                    ProjectId = model.ProjectId,
                    Resolved = model.Resolved,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.RunTimeErrors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RunTimeErrorListItem> GetRunTimeErrors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .RunTimeErrors
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new RunTimeErrorListItem
                        {
                            ErrorId = e.ErrorId,
                            Title = e.Title,
                            Resolved = e.Resolved,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }

        public RunTimeErrorDetail GetRunTimeErrorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RunTimeErrors
                    .Single(e => e.ErrorId == id && e.OwnerId == _userId);
                return
                    new RunTimeErrorDetail
                    {
                        Title = entity.Title,
                        ErrorId = entity.ErrorId,
                        LineNumber = entity.LineNumber,
                        RunTimeMessage = entity.RunTimeMessage,
                        Resolved = entity.Resolved,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateRunTimeError(RunTimeErrorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RunTimeErrors
                    .Single(e => e.ErrorId == model.ErrorId && e.OwnerId == _userId);
                entity.Title = model.Title;
                entity.Resolved = model.Resolved;
                entity.LineNumber = model.LineNumber;
                entity.RunTimeMessage = model.RunTimeMessage;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRunTimeError(int errorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                .RunTimeErrors
                .Single(e => e.ErrorId == errorId && e.OwnerId == _userId);

                ctx.RunTimeErrors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

        }
    }
}
