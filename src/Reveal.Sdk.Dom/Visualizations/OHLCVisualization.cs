using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class OHLCVisualization : FinancialVisualizationBase<OHLCVisualizationSettings>
    {
        internal OHLCVisualization() : this(null) { }
        public OHLCVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public OHLCVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
