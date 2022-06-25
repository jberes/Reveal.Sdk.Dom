using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class GaugeVisualization : LinearGaugeVisualizationBase<GaugeVisualizationSettings>
    {
        internal GaugeVisualization() : this(null) { }

        public GaugeVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
