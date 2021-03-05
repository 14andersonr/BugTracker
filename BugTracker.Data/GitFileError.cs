using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data
{
    public class GitFileError : Error
    {
        [Required]
        public string GitFileMessage { get; set; }
    }
}
