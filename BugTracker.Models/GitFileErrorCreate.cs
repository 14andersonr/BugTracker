using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class GitFileErrorCreate : ErrorCreate
    {
        [Required]
        [MaxLength(2000, ErrorMessage = "There are too many characters in this field.")]
        public string GitFileMessage { get; set; }
    }
}
