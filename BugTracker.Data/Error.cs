using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data
{
    public class Error
    {
        [Key]
        public int ErrorId { get; set; }

        [ForeignKey(nameof(Project))] //ForeignKey has a nameof and a public virtual.
        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }


        [Required]
        public bool Resolved { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public int LineNumber { get; set; }
    }
}
