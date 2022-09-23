using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The stacked column visualization is used to break down and compare parts of a whole, where the column represent parts of a whole. The segments in the column illustrate different categories and colors are used to differentiate between them.
    /// </summary>
    public sealed class StackedColumnChartVisualization : CategoryVisualizationBase<StackedColumnChartVisualizationSettings>
    {
        internal StackedColumnChartVisualization() : this(null) { }

        /// <summary>
        /// Creates a stacked column visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public StackedColumnChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        /// <summary>
        /// Creates a stacked column visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The data soure item used to represent a dataset.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public StackedColumnChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
