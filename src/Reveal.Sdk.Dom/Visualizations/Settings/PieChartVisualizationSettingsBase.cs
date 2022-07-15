using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class PieChartVisualizationSettingsBase : ChartVisualizationSettingsBase
    {
        public PieChartVisualizationSettingsBase() { }
        
        /// <summary>
        /// Gets or sets the how the slice labels are displayed. Display only the values, only the percentages, or both.
        /// </summary>
        [JsonProperty("LabelDisplayMode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LabelDisplayMode SliceLabelDisplay { get; set; }
    }
}
