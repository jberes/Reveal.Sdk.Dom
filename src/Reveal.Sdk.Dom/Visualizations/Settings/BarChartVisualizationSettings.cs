using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public sealed class BarChartVisualizationSettings : CategoryChartVisualizationSettings
    {
        public BarChartVisualizationSettings()
        {
            ChartType = RdashChartType.Bar;
        }

        [JsonProperty("CategoryAxisOverlap")]
        public double Overlap { get; set; } = -0.2;

        [JsonProperty("CategoryAxisGap")]
        public double Gap { get; set; } = 0.4;
    }
}
