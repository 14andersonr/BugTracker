﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data
{
    public class BuildError : Error
    {
        [Required]
        public string BuildErrorMessage { get; set; }          
    }
}
