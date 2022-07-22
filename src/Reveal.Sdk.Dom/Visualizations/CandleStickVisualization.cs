using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class CandleStickVisualization : FinancialVisualizationBase<CandleStickVisualizationSettings>
    {
        internal CandleStickVisualization() : this(null) { }
        public CandleStickVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public CandleStickVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
