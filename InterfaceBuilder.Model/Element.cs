using Newtonsoft.Json;
using System.Collections.Generic;

namespace InterfaceBuilder.Model
{
    public class Element
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        [JsonProperty(PropertyName = "defaultValue")]
        public string DefaultValue { get; set; }

        [JsonProperty(PropertyName = "hint")]
        public string Hint { get; set; }

        [JsonProperty(PropertyName = "controls")]
        public List<Element> Elements { get; set; }
    }
}