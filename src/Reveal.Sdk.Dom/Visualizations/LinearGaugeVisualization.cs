using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class LinearGaugeVisualization : LinearGaugeVisualizationBase<LinearGaugeVisualizationSettings>
    {
        internal LinearGaugeVisualization() : this(null) { }
        public LinearGaugeVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public LinearGaugeVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
