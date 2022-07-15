using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class RadialChartVisualizationSettings : ChartVisualizationSettings
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

        //todo: implement properties
        //ZoomLevel
        //AutomaticLabelRotation
        //SyncAxis
    }
}
