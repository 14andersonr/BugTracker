using BugTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class BuildErrorEdit : ErrorEdit
    {
        public new int ErrorId { get; set; }
        public new bool Resolved { get; set; }
        public new string Title { get; set; }
        public string BuildErrorMessage { get; set; }
        public int LineNumber { get; set; }
    }
}
