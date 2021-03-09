using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data
{
    public class ProjectsJson
    {
        [JsonProperty("ProjectId")]
        public int ProjectId { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("CreatedUtc")]
        public DateTime CreatedUtc { get; set; }
    }
}
