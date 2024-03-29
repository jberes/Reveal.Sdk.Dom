using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The spline area visualization is used for rendering a collection of points connected by smooth curves with the area below the line filled in. Values are represented on the y-axis and categories are displayed on the x-axis.
    /// </summary>
    public sealed class SplineAreaChartVisualization : CategoryVisualizationBase<SplineAreaChartVisualizationSettings>
    {
        internal SplineAreaChartVisualization() : this(null) { }

        /// <summary>
        /// Creates a spline area visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public SplineAreaChartVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a spline area visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public SplineAreaChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { ChartType = ChartType.SplineArea; }
    }
}
