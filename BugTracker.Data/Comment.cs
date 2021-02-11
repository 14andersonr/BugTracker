using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data
{
   public class Comment
    {
        [Key]
      
        public string Text { get; set; }
        [Required]
        public string Title { get; set; }
        public int CommentId { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
        
        //[ForeignKey](nameof(Error))]

       // public int? ErrorId {get; set;}

       // public virtual Error Error {get; se;}
    }
}
