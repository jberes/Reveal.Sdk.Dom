using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The circular gauge visualization displays a semi circle that contains minimum & maximum thresholds along with the current value. The circular gauge paints the scale background with the color of the current range.
    /// </summary>
    public sealed class CircularGaugeVisualization : SingleGaugeVisualizationBase<CircularGaugeVisualizationSettings>
    {
        internal CircularGaugeVisualization() : this(null) { }

        /// <summary>
        /// Creates a circular gauge visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public CircularGaugeVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a circular gauge visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public CircularGaugeVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
