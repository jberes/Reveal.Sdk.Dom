using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public sealed class RadialVisualizationSettings : ChartVisualizationSettings
    {
        public RadialVisualizationSettings()
        {
            ChartType = RdashChartType.RadialLines;
        }

        /// <summary>
        /// Gets or sets a trendline to apply to the visualization
        /// </summary>
        [JsonProperty("TrendlineType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TrendlineType Trendline { get; set; }
    }
}
