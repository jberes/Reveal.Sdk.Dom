using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class OHCLVisualization : FinancialVisualizationBase<OHCLVisualizationSettings>
    {
        internal OHCLVisualization() : this(null) { }
        public OHCLVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
        public OHCLVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

    }
}
