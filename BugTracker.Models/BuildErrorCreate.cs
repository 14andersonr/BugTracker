using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class BuildErrorCreate : Error
    {
        [Required]
        [MinLength(1, ErrorMessage = "PLease enter at least 1 number.")]
        [MaxLength(5, ErrorMessage = "Maximum of 5 digits allowed.")]
        public int LineNumber { get; set; }

        [Required]
        [MaxLength(2000, ErrorMessage = "There are too many characters in this field.")]
        public string BuildErrorMessage { get; set; }
    }
}
