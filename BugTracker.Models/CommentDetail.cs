using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
   public class CommentDetail
    {
        public int CommentId { get; set; }
        public string Text { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset? CreatedUtc { get; set; }
        public int? ErrorId { get; set; }

        public virtual CommentListItem Error { get; set; }
        public string Content { get; set; }
    }
}
