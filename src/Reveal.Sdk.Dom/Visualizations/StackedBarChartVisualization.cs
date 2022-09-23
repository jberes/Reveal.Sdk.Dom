using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The stacked bar visualization is used to break down and compare parts of a whole, where the bars represent parts of a whole. The segments in the bar illustrate different categories and colors are used to differentiate between them.
    /// </summary>
    public sealed class StackedBarChartVisualization : CategoryVisualizationBase<StackedBarChartVisualizationSettings>
    {
        internal StackedBarChartVisualization() : this(null) { }

        /// <summary>
        /// Creates a stacked bar visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public StackedBarChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        /// <summary>
        /// Creates a stacked bar visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public StackedBarChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
