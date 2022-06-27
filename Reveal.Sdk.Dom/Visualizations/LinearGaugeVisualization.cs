using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class LinearGaugeVisualization : LinearGaugeVisualizationBase<GaugeVisualizationSettings>
    {
        internal LinearGaugeVisualization() : this(null) { }

        public LinearGaugeVisualization(DataSourceItem dataSourceItem) : this(string.Empty, dataSourceItem) { }

        public LinearGaugeVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) 
        {
            Settings.ViewType = GaugeViewType.Linear;
        }
    }
}
