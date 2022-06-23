using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class CircularGaugeVisualization : Visualization<GaugeVisualizationSettings, SingleGaugeVisualizationDataSpec>
    {
        internal CircularGaugeVisualization() : this(null) { }

        public CircularGaugeVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) 
        {
            Settings.ViewType = GaugeViewType.Circular;
        }
    }
}
