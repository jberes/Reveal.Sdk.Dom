using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class KpiTargetVisualization : KpiTargetVisualizationBase<KpiTargetVisualizationSettings>
    {
        internal KpiTargetVisualization() : this(null) { }

        public KpiTargetVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
