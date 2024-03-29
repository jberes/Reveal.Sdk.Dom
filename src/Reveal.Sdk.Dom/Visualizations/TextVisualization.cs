using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The text visualization is used for displaying a single value field's aggregation, such as average, count, sum, etc.
    /// </summary>
    public sealed class TextVisualization : SingleGaugeVisualizationBase<TextVisualizationSettings>
    {
        internal TextVisualization() : this(null) { }

        /// <summary>
        /// Creates a text visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public TextVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a text visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public TextVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { ChartType = ChartType.Text; }
    }
}
