using BugTracker.Data;
using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Services
{
    public class GitFileErrorService
    {
        private readonly Guid _userId;

        public GitFileErrorService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGitFileError(GitFileErrorCreate model)
        {
            var entity =
                new GitFileError()
                {
                    OwnerId = _userId,
                    Title = model.Title,                    
                    GitFileMessage = model.GitFileMessage,
                    ProjectId = model.ProjectId,
                    Resolved = model.Resolved,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.GitFileErrors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GitFileErrorListItem> GetGitFileErrors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .GitFileErrors
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new GitFileErrorListItem
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

        public GitFileErrorDetail GetGitFileErrorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .GitFileErrors
                    .Single(e => e.ErrorId == id && e.OwnerId == _userId);
                return
                    new GitFileErrorDetail
                    {
                        Title = entity.Title,
                        ErrorId = entity.ErrorId,                        
                        GitFileMessage = entity.GitFileMessage,
                        Resolved = entity.Resolved,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateGitFileError(GitFileErrorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .GitFileErrors
                    .Single(e => e.ErrorId == model.ErrorId && e.OwnerId == _userId);
                entity.Title = model.Title;
                entity.Resolved = model.Resolved;                
                entity.GitFileMessage = model.GitFileMessage;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGitFileError(int errorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                .GitFileErrors
                .Single(e => e.ErrorId == errorId && e.OwnerId == _userId);

                ctx.GitFileErrors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
