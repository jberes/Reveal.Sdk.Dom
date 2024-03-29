using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The spline visualization is used for rendering a collection of points connected by smooth curves. Values are represented on the y-axis and categories are displayed on the x-axis.
    /// </summary>
    public sealed class SplineChartVisualization : CategoryVisualizationBase<SplineChartVisualizationSettings>
    {
        internal SplineChartVisualization() : this(null) { }

        /// <summary>
        /// Creates a spline visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public SplineChartVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a spline visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public SplineChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { ChartType = ChartType.Spline; }
    }
}
