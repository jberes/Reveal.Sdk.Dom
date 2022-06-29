using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class GridVisualizationSettings : VisualizationSettings
    {
        public bool HideGrandTotals { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public FontSize FontSize { get; set; } = FontSize.Small;

        [JsonProperty]
        public GridVisualizationStyle Style { get; private set; } = new GridVisualizationStyle();

        [JsonProperty]
        public List<VisualizationColumnStyle> VisualizationColumns { get; private set; } = new List<VisualizationColumnStyle>();
    }
}
