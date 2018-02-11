using Newtonsoft.Json;
using System.Collections.Generic;

namespace InterfaceBuilder.Model
{
    public class Window
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "controls")]
        public List<Element> Elements { get; set; }

        [JsonProperty(PropertyName = "tabs")]
        public List<Tab> Tabs { get; set; }
    }
}