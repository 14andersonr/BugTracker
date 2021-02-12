using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class BuildErrorDetail : Error
    {
        public int ErrorId { get; set; }
        public int LineNumber { get; set; }
        public string BuildErrorMessage { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
