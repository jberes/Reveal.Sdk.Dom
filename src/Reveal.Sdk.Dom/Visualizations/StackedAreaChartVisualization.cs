using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The stacked area visualization is used for showing plotted data as filled areas stacked, one on top of the other. A stacked area visualization can show how part to whole relationships change over time.
    /// </summary>
    public sealed class StackedAreaChartVisualization : CategoryVisualizationBase<StackedAreaChartVisualizationSettings>
    {
        internal StackedAreaChartVisualization() : this(null) { }

        /// <summary>
        /// Creates a stacked area visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public StackedAreaChartVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a stacked area visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public StackedAreaChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { ChartType = ChartType.StackedArea; }
    }
}
