using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The candlestick visualization is used for the technical analysis of the price ranges. A candlestick chart compares the high and low prices of a day to the open and close of the ticker symbol.
    /// </summary>
    public sealed class CandleStickVisualization : FinancialVisualizationBase<CandleStickVisualizationSettings>
    {
        internal CandleStickVisualization() : this(null) { }

        /// <summary>
        /// Creates a candlestick visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public CandleStickVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a candlestick visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public CandleStickVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { ChartType = ChartType.Candlestick; }
    }
}
