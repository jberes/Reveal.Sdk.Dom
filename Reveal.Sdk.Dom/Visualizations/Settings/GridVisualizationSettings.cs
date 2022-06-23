using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class GridVisualizationSettings : VisualizationSettings
    {
        public bool HideGrandTotals { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public FontSizeType FontSize { get; set; } = FontSizeType.Small;
        public GridVisualizationStyle Style { get; set; } = new GridVisualizationStyle();
        public List<VisualizationColumnStyle> VisualizationColumns { get; set; } = new List<VisualizationColumnStyle>();
    }
}
