using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class FunnelChartVisualization : Visualization<FunnelChartVisualizationSettings, SingleValueLabelsVisualizationDataSpec>
    {
        public FunnelChartVisualization() : base() { }

        public FunnelChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
