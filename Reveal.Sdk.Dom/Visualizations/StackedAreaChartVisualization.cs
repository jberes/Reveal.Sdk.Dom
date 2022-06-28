using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class StackedAreaChartVisualization : CategoryVisualizationBase<StackedAreaChartVisualizationSettings>
    {
        internal StackedAreaChartVisualization() : this(null) { }

        public StackedAreaChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        public StackedAreaChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
