using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The funnel chart visualization is used to display quantities as percentages of a whole, much like a pie chart. Funnel charts are commonly used to display quantitative data in relation to stages of a process.
    /// </summary>
    public sealed class FunnelChartVisualization : SingleValueLabelsVisualizationBase<FunnelChartVisualizationSettings>
    {
        internal FunnelChartVisualization() : this(null) { }

        /// <summary>
        /// Creates a funnel chart visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public FunnelChartVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a funnel chart visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public FunnelChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
