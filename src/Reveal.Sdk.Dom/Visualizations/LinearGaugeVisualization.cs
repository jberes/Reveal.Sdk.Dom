using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The linear gauge visualization is used for displaying a single value, or a list of values, comparing them with range thresholds.
    /// </summary>
    public sealed class LinearGaugeVisualization : LinearGaugeVisualizationBase<LinearGaugeVisualizationSettings>
    {
        internal LinearGaugeVisualization() : this(null) { }

        /// <summary>
        /// Creates a linear gauge visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public LinearGaugeVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a linear gauge visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public LinearGaugeVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { ChartType = ChartType.LinearGauge; }
    }
}
