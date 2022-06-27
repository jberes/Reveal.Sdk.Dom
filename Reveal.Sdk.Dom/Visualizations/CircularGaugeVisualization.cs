using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class CircularGaugeVisualization : SingleGaugeVisualizationBase<GaugeVisualizationSettings>
    {
        internal CircularGaugeVisualization() : this(null) { }

        public CircularGaugeVisualization(DataSourceItem dataSourceItem) : this(string.Empty, dataSourceItem) { }

        public CircularGaugeVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem)
        {
            Settings.ViewType = GaugeViewType.Circular;
        }
    }
}
