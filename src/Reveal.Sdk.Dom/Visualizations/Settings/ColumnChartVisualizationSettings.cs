using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public sealed class ColumnChartVisualizationSettings : CategoryChartVisualizationSettings
    {
        public ColumnChartVisualizationSettings()
        {
            ChartType = RdashChartType.Column;
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
