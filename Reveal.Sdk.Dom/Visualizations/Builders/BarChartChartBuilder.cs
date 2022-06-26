using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations.Builder
{
    public class BarChartChartBuilder : ChartBuilder<BarChartVisualization, BarChartVisualizationSettings>
    {
        public BarChartChartBuilder(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem)
        {
        }
    }
}
