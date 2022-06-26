using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations.Builder
{
    public class LineChartChartBuilder : ChartBuilder<LineChartVisualization, LineChartVisualizationSettings>
    {
        public LineChartChartBuilder(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem)
        {
        }
    }
}
