﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class BuildErrorListItem : Error
    {
        public int ErrorId { get; set; }
        public string Title { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}