using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    //todo: move to another file
    internal struct ColumnConfig
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("dateFormat")]
        public string DateFormat { get; set; }

        [JsonProperty("uniqueName")]
        public string UniqueName { get; set; }
    }

}
