using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class ChartVisualizationSettings : ChartVisualizationSettingsBase
    {
        public ChartVisualizationSettings() : base() { }

        /// <summary>
        /// Gets or sets if the left axis will use the Logarithmic scale. Linear is used by default.
        /// </summary>
        [JsonProperty("LeftAxisLogarithmic")]
        public bool LeftAxisIsLogarithmic { get; set; }

        /// <summary>
        /// Gets or sets the minimum value for the left axis. Default value is 0.
        /// </summary>
        [JsonProperty]
        public double? LeftAxisMinValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum value for the left axis. Default value is calculated automatically depending on the values.
        /// </summary>
        [JsonProperty]
        public double? LeftAxisMaxValue { get; set; }

        /// <summary>
		/// Gets or sets a trendline to apply to the visualization
		/// </summary>
		[JsonProperty("TrendlineType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TrendlineType Trendline { get; set; }


        //todo: does not apply to pie, doughnut, funnel, combo,
        [JsonProperty]
        internal bool ShowTotalsInTooltip { get; set; }

        //todo: looks like stack series charts only
        [JsonProperty]
        internal bool? IsPercentageDistributed { get; set; }
    }
}
