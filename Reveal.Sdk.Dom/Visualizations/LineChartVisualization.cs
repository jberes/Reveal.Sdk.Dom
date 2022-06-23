using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class LineChartVisualization : Visualization<LineChartVisualizationSettings, CategoryVisualizationDataSpec>
    {
        internal LineChartVisualization() : this(null) { }

        public LineChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
