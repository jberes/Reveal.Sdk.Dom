using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class CircularGaugeVisualization : SingleGaugeVisualizationBase<CircularGaugeVisualizationSettings>
    {
        internal CircularGaugeVisualization() : this(null) { }

        public CircularGaugeVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        public CircularGaugeVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
