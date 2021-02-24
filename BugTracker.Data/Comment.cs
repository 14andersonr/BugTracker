using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data
{
   public class Comment
    {
        [Key]
        [Required]
        public string Text { get; set; }
        [Required]
        public int CommentId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public string Content { get; set; }
       
        public DateTimeOffset CreatedUtc { get; set; }
        
        [ForeignKey(nameof(Error))]

        public int? ErrorId {get; set;}

        public virtual Error Error {get; set;}
    }
}
