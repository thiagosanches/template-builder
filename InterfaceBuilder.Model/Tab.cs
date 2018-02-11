using Newtonsoft.Json;
using System.Collections.Generic;

namespace InterfaceBuilder.Model
{
    public class Tab
    {
        [JsonProperty(PropertyName = "name")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "controls")]
        public List<Element> Elements { get; set; }
    }
}
