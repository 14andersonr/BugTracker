using BugTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class CommentEdit
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public string content { get; set; }
        //public int? ErrorId { get; set; }
        public virtual Error Error { get; set; }
    }

}