using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class GridVisualizationStyle
    {
        public bool FixedLeftColumns { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TextAlignment TextAlignment { get; set; } = TextAlignment.Inherit;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TextAlignment NumericAlignment { get; set; } = TextAlignment.Inherit;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TextAlignment DateAlignment { get; set; } = TextAlignment.Inherit;
    }
}
