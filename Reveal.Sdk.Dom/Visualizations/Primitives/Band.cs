using Reveal.Sdk.Dom.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class Band : SchemaType
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public BandType Type { get; set; } = BandType.Percentage;

        [JsonConverter(typeof(StringEnumConverter))]
        public BandColorType Color { get; set; } = BandColorType.Blue;

        public double? Value { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ShapeType Shape { get; set; } = ShapeType.None;
    }
}
