using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class ErrorEdit
    {
        public int ErrorId { get; set; }
        public string Title { get; set; }
        public bool Resolved { get; set; }
    }
}
