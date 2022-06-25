using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class FunnelChartVisualization : SingleValueLabelsVisualizationBase<FunnelChartVisualizationSettings>
    {
        internal FunnelChartVisualization() : this(null) { }

        public FunnelChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
