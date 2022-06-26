using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations.Builder
{
    public class SplineAreaChartBuilder : ChartBuilder<SplineAreaChartVisualization, SplineAreaChartVisualizationSettings>
    {
        public SplineAreaChartBuilder(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem)
        {
        }
    }
}
