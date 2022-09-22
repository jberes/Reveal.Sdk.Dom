using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The bar chart visualization is among the most common category chart types used to quickly compare frequency, count, total, or  average of data in different categories with data encoded by horizontal bars with equal heights but different lengths. This chart is ideal for showing variations in the value of an item over time. Data is represented using a collection of rectangles that extend from the left to right of the chart towards the values of data points.
    /// </summary>
    public sealed class BarChartVisualization : CategoryVisualizationBase<BarChartVisualizationSettings>
    {
        internal BarChartVisualization() : this(null) { }

        /// <summary>
        /// Creates a bar chart visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public BarChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        /// <summary>
        /// Creates a bar chart visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public BarChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
