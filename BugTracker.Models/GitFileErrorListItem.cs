using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class GitFileErrorListItem : ErrorListItem
    {
        public new int ErrorId { get; set; }
        public new string Title { get; set; }
        public new DateTimeOffset CreatedUtc { get; set; }
    }
}
