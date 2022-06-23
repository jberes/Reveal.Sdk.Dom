using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class PieChartVisualization : Visualization<PieChartVisualizationSettings, SingleValueLabelsVisualizationDataSpec>
    {
        internal PieChartVisualization() : this(null) { }

        public PieChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
