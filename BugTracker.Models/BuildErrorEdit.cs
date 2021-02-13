using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    class BuildErrorEdit : Error
    {
        public int ErrorId { get; set; }
        public bool Resolved { get; set; }
        public string Title { get; set; }
        public string BuildErrorMessage { get; set; }
        public int LineNumber { get; set; }
    }
}
