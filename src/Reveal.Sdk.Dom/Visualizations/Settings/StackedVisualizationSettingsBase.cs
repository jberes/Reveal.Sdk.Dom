using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public abstract class StackedVisualizationSettingsBase : ChartVisualizationSettings
    {
        protected StackedVisualizationSettingsBase() : base() { }

        /// <summary>
        /// Gets or sets whether to override the 0-100 default scale and visualize the percentage distribution of the values.
        /// </summary>
        [JsonProperty]
        public bool? IsPercentageDistributed { get; set; }
    }
}
