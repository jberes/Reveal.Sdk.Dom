using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class TextVisualization : SingleGaugeVisualizationBase<TextVisualizationSettings>
    {
        internal TextVisualization() : this(null) { }
        public TextVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public TextVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
