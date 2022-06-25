using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class CircularGaugeVisualization : SingleGaugeVisualizationBase<GaugeVisualizationSettings>
    {
        internal CircularGaugeVisualization() : this(null) { }

        public CircularGaugeVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) 
        {
            Settings.ViewType = GaugeViewType.Circular;
        }
    }
}
