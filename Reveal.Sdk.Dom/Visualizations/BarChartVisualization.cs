using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class BarChartVisualization : Visualization<BarChartVisualizationSettings, CategoryVisualizationDataSpec>
    {
        public BarChartVisualization() : base() { }

        public BarChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
