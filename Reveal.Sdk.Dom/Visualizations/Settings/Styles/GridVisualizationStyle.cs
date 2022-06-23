using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class GridVisualizationStyle
    {
        public bool FixedLeftColumns { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TextAlignment TextAlignment { get; set; } = TextAlignment.Inherit;

        [JsonConverter(typeof(StringEnumConverter))]
        public TextAlignment NumericAlignment { get; set; } = TextAlignment.Inherit;

        [JsonConverter(typeof(StringEnumConverter))]
        public TextAlignment DateAlignment { get; set; } = TextAlignment.Inherit;
    }
}
