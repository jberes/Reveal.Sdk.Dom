using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations.Builder
{
    public class StackedColumnChartBuilder : ChartBuilder<StackedColumnChartVisualization, StackedColumnChartVisualizationSettings>
    {
        public StackedColumnChartBuilder(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem)
        {
        }
    }
}
