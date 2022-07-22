using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class FunnelChartVisualization : SingleValueLabelsVisualizationBase<FunnelChartVisualizationSettings>
    {
        internal FunnelChartVisualization() : this(null) { }
        public FunnelChartVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public FunnelChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
