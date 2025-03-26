using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public sealed class ColumnChartVisualizationSettings : CategoryChartVisualizationSettings
    {
        public ColumnChartVisualizationSettings()
        {
            ChartType = RdashChartType.Column;
        }

        [JsonProperty("CategoryAxisOverlap")]
        public double Overlap { get; set; } = -0.2;

        [JsonProperty("CategoryAxisGap")]
        public double Gap { get; set; } = 0.4;
    }
}
