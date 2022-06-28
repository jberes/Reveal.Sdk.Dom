using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class StackedBarChartVisualization : CategoryVisualizationBase<StackedBarChartVisualizationSettings>
    {
        internal StackedBarChartVisualization() : this(null) { }

        public StackedBarChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        public StackedBarChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
