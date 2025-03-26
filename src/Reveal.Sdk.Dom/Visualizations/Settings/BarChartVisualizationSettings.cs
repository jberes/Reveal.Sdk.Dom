using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public sealed class BarChartVisualizationSettings : CategoryChartVisualizationSettings
    {
        public BarChartVisualizationSettings()
        {
            ChartType = RdashChartType.Bar;
        }

        /// <summary>
        /// Gets or sets the gap between the bars in the chart. The value is a percentage of the bar width.
        /// </summary>
        [JsonProperty("CategoryAxisGap")]
        public double Gap { get; set; } = 0.4;

        /// <summary>
        /// Gets or sets the overlap between the bars in the chart. The value is a percentage of the bar width.
        /// </summary>
        [JsonProperty("CategoryAxisOverlap")]
        public double Overlap { get; set; } = -0.2;
    }
}
