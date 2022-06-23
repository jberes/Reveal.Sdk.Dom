using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class GaugeVisualization : Visualization<GaugeVisualizationSettings, LinearGaugeVisualizationDataSpec>
    {
        internal GaugeVisualization() : this(null) { }

        public GaugeVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
