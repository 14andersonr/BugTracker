using BugTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
   public class CommentCreate
    {
        [Required]
        public string Text { get; set; }
        //[ForeignKey(nameof(Error))]

        // public int? ErroId { get; set; }

        //public virtual Error Error { get; set; }
    }
}
