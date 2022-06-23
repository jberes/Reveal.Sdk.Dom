using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class GridVisualizationSettings : VisualizationSettings
    {
        public bool HideGrandTotals { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FontSizeType FontSize { get; set; } = FontSizeType.Small;
        public GridVisualizationStyle Style { get; set; } = new GridVisualizationStyle();
        public List<VisualizationColumnStyle> VisualizationColumns { get; set; } = new List<VisualizationColumnStyle>();
    }
}
