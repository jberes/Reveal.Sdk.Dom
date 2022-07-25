using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class RadialVisualization : CategoryVisualizationBase<RadialVisualizationSettings>
    {
        internal RadialVisualization() : this(null) { }
        public RadialVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
        public RadialVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
