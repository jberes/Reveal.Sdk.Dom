using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class GaugeVisualization : Visualization<GaugeVisualizationSettings, LinearGaugeVisualizationDataSpec>
    {
        public GaugeVisualization() : base() { }

        public GaugeVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
