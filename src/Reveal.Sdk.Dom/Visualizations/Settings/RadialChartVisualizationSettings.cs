using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class RadialChartVisualizationSettings : ChartVisualizationSettingsBase
    {
        public RadialChartVisualizationSettings()
        {
            ChartType = ChartType.RadialLines;
        }

        /// <summary>
        /// Gets or sets a trendline to apply to the visualization
        /// </summary>
        [JsonProperty("TrendlineType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TrendlineType Trendline { get; set; }
    }
}
