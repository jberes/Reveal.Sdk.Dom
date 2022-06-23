using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class KpiTargetVisualization : Visualization<KpiTargetVisualizationSettings, KpiTargetVisualizationDataSpec>
    {
        internal KpiTargetVisualization() : this(null) { }

        public KpiTargetVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
