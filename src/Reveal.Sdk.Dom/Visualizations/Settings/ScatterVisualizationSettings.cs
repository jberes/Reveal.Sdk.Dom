using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class ScatterVisualizationSettings : YAxisVisualizationSettings
    {
        public ScatterVisualizationSettings()
        {
            ChartType = ChartType.Scatter;
        }

        /// <summary>
        /// Gets or sets if the X axis will use the Logarithmic scale. Linear is used by default.
        /// </summary>
        [JsonProperty("RightAxisLogarithmic")]
        public bool XAxisIsLogarithmic { get; set; }

        /// <summary>
        /// Gets or sets the minimum value for the X axis. Default value is 0.
        /// </summary>
        [JsonProperty("RightAxisMinValue")]
        public double? XAxisMinValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum value for the X axis. Default value is calculated automatically depending on the values.
        /// </summary>
        [JsonProperty("RightAxisMaxValue")]
        internal double? XAxisMaxValue { get; set; }
    }
}
