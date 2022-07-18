using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class ShapeBand : Band
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ShapeType Shape { get; set; } = ShapeType.Circle;
    }
}
