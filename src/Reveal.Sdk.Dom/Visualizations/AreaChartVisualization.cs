using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The area chart visualization renders as a collection of points connected by straight line segments with the area below the line filled in. Values are represented on the y-axis and categories are displayed on the x-axis. This chart emphasize the amount of change over a period of time or compare multiple items as well as the relationship of parts of a whole by displaying the total of the plotted values. Therefore, they are often chronological, showing a change of quantity e.g. accumulation of a commodity over time.
    /// </summary>
    public sealed class AreaChartVisualization : CategoryVisualizationBase<AreaChartVisualizationSettings>
    {
        internal AreaChartVisualization() : this(null) { }

        /// <summary>
        /// Creates an area chart visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public AreaChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        /// <summary>
        /// Creates an area chart visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public AreaChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
