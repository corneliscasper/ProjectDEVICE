using System;
using Newtonsoft.Json;

namespace proj.Models
{
    public class Trellocard
    {
        [JsonProperty(PropertyName = "id")]
        public string CardId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
