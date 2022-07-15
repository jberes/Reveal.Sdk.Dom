using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class PieChartVisualizationSettings : PieChartVisualizationSettingsBase
    {
        public PieChartVisualizationSettings()
        {
            ChartType = ChartType.Pie;
        }
        
        /// <summary>
        /// Gets or sets the slice rotation, in degrees, to change the order in which your data is presented. Supported values include 0, 90, 180, and 270.
        /// </summary>
        [JsonProperty("PieStartPosition")]
        public int? StartPosition { get; set; }
        
        /// <summary>
        /// Gets or sets the option to see all data values in the field added as the "Label", including data items with the value of 0 (zero).
        /// </summary>
        [JsonProperty]
        public bool ShowZeroValuesInLegend { get; set; }
    }
}
