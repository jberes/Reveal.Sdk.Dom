using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class IndicatorVisualization : IndicatorVisualizationBase<IndicatorVisualizationSettings>
    {
        internal IndicatorVisualization() : this(null) { }

        public IndicatorVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        public IndicatorVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
