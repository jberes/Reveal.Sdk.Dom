using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class StackedColumnChartVisualization : Visualization<StackedColumnChartVisualizationSettings, CategoryVisualizationDataSpec>
    {
        public StackedColumnChartVisualization() : base() { }

        public StackedColumnChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
