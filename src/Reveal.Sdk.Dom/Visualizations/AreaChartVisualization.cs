using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class AreaChartVisualization : CategoryVisualizationBase<AreaChartVisualizationSettings>
    {
        internal AreaChartVisualization() : this(null) { }

        public AreaChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        public AreaChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
