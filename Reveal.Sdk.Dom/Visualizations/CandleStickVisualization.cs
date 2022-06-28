using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class CandleStickVisualization : FinancialVisualizationBase<CandleStickVisualizationSettings>
    {
        internal CandleStickVisualization() : this(null) { }
        public CandleStickVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
        public CandleStickVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
