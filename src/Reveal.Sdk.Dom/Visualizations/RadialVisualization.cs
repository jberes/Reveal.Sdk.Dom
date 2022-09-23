using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The radial visualization is used for taking data and rendering it as collection of data points wrapped around a circle (rather than stretching along a horizontal line).
    /// </summary>
    public sealed class RadialVisualization : CategoryVisualizationBase<RadialVisualizationSettings>
    {
        internal RadialVisualization() : this(null) { }

        /// <summary>
        /// Creates a radial visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public RadialVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        /// <summary>
        /// Creates a radial visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public RadialVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
