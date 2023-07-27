using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class LinkFilter
    {
        public LinkFilter() { }

        public LinkFilter(string name, string targetFilterId, string value, LinkFilterType linkFilterType = LinkFilterType.Column)
            //: this(targetFilterId, value, linkFilterType)
        {
            Name = name;
            TargetFilterId = targetFilterId;
            Value = value;
            Type = linkFilterType;
        }

        /// <summary>
        /// The name of the filter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The filter ID of the target dashboard that will be used to map the <see cref="Value"/> to the target dashboard's filter.
        /// </summary>
        [JsonProperty("Namespace")]
        public string TargetFilterId { get; set; }

        /// <summary>
        /// The type of the filter.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LinkFilterType Type { get; set; } = LinkFilterType.Column;

        /// <summary>
        /// The value of the filter.
        /// </summary>
        public string Value { get; set; }
    }
}
