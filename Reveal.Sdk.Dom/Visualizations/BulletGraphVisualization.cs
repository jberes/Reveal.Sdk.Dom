using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class BulletGraphVisualization : LinearGaugeVisualizationBase<GaugeVisualizationSettings>
    {
        internal BulletGraphVisualization() : this(null) { }

        public BulletGraphVisualization(DataSourceItem dataSourceItem) : this(string.Empty, dataSourceItem) { }

        public BulletGraphVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem)
        {
            Settings.ViewType = GaugeViewType.BulletGraph;
        }
    }
}
