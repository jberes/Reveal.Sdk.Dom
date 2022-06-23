using Reveal.Sdk.Dom.Core;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class Band : SchemaType
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BandType Type { get; set; } = BandType.Percentage;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BandColorType Color { get; set; } = BandColorType.Blue;

        public double? Value { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ShapeType Shape { get; set; } = ShapeType.None;
    }
}
