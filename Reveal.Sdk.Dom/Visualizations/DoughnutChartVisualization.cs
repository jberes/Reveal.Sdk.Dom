using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class DoughnutChartVisualization : Visualization<DoughnutChartVisualizationSettings, SingleValueLabelsVisualizationDataSpec>
    {
        internal DoughnutChartVisualization() : this(null) { }

        public DoughnutChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
