using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The doughnut visualization is used to proportionally illustrate the occurrences of a variable by drawing arc segments around a center point that is empty, like a doughnut.
    /// </summary>
    public sealed class DoughnutChartVisualization : SingleValueLabelsVisualizationBase<DoughnutChartVisualizationSettings>
    {
        internal DoughnutChartVisualization() : this(null) { }

        /// <summary>
        /// Creates a doughnut chart visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public DoughnutChartVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a doughnut chart visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public DoughnutChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
