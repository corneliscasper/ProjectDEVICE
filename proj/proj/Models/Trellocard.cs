using System;
using Newtonsoft.Json;

namespace proj.Models
{
    public class Trellocard
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
