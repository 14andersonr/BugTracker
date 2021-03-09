using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class RunTimeErrorDetail : ErrorDetail
    {
        public new int ErrorId { get; set; }
        public int LineNumber { get; set; }
        public string RunTimeMessage { get; set; }
        public new DateTimeOffset CreatedUtc { get; set; }
        public new DateTimeOffset? ModifiedUtc { get; set; }
    }
}
