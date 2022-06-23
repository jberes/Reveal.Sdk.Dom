using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class SplineAreaChartVisualization : Visualization<SplineAreaChartVisualizationSettings, CategoryVisualizationDataSpec>
    {
        internal SplineAreaChartVisualization() : this(null) { }

        public SplineAreaChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
