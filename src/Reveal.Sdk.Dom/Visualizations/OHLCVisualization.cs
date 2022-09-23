using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The OHLC visualization is used for the technical analysis of the price ranges. Like <see cref="CandleStickVisualization"/>, OHLC charts are meant to show the opening, high, low and closing prices for any financial data.
    /// </summary>
    public sealed class OHLCVisualization : FinancialVisualizationBase<OHLCVisualizationSettings>
    {
        internal OHLCVisualization() : this(null) { }

        /// <summary>
        /// Creates a OHLC visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public OHLCVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a OHLC visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public OHLCVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
