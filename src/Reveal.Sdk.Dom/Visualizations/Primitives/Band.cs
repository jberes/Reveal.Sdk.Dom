using Reveal.Sdk.Dom.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class Band : SchemaType
    {
        [JsonProperty("Type")]
        [JsonConverter(typeof(StringEnumConverter))]
        internal ValueComparisonType ValueComparisonType { get; set; } = ValueComparisonType.Percentage;

        [JsonConverter(typeof(StringEnumConverter))]
        public BandColor Color { get; set; } = BandColor.Green;
        
        public double? Value { get; set; }
    }
}
