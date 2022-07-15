using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public abstract class StackedVisualizationSettingsBase : SharedChartVisualizationSettings
    {
        protected StackedVisualizationSettingsBase() : base() { }

        /// <summary>
        /// Gets or sets whether to override the 0-100 default scale and visualize the percentage distribution of the values.
        /// </summary>
        [JsonProperty]
        public bool? IsPercentageDistributed { get; set; }

        /// <summary>
        /// Gets or sets whether a total (sum) of values will be displayed in the tooltip. Only applied when categories have been added to the visualization.
        /// </summary>
        [JsonProperty]
        internal bool ShowTotalsInTooltip { get; set; }
    }
}
