using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class GitFileErrorDetail : ErrorDetail
    {
        public new int ErrorId { get; set; }        
        public string GitFileMessage { get; set; }
        public new DateTimeOffset CreatedUtc { get; set; }
        public new DateTimeOffset? ModifiedUtc { get; set; }
    }
}
