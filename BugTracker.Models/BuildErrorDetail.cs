using BugTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class BuildErrorDetail : Error
    {
        public new int ErrorId { get; set; }
        public int LineNumber { get; set; }
        public string BuildErrorMessage { get; set; }
        public new DateTimeOffset CreatedUtc { get; set; }
        public new DateTimeOffset? ModifiedUtc { get; set; }
    }
}
