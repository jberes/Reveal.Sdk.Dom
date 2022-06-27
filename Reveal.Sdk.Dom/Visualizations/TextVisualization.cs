using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class TextVisualization : SingleGaugeVisualizationBase<GaugeVisualizationSettings>
    {
        internal TextVisualization() : this(null) { }

        public TextVisualization(DataSourceItem dataSourceItem) : this(string.Empty, dataSourceItem) { }

        public TextVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem)
        {
            Settings.ViewType = GaugeViewType.SingleValue;
            Settings.ConditionalFormattingEnabled = false;
        }
    }
}
