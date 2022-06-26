using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations.Builder
{
    public class ColumnChartChartBuilder : ChartBuilder<ColumnChartVisualization, ColumnChartVisualizationSettings>
    {
        public ColumnChartChartBuilder(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem)
        {
        }
    }
}
