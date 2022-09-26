using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The step line visualization is used for rendering a collection of points connected by continuous vertical and horizontal lines.
    /// </summary>
    public sealed class StepLineChartVisualization : CategoryVisualizationBase<StepLineChartVisualizationSettings>
    {
        internal StepLineChartVisualization() : this(null) { }

        /// <summary>
        /// Creates a step line visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public StepLineChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        /// <summary>
        /// Creates a step line visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The data soure item used to represent a dataset.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public StepLineChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
