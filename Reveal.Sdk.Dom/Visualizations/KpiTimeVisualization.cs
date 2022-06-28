using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class KpiTimeVisualization : IndicatorVisualizationBase<IndicatorVisualizationSettings>
    {
        internal KpiTimeVisualization() : this(null) { }

        public KpiTimeVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        public KpiTimeVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
