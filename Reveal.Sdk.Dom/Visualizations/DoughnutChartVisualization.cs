using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class DoughnutChartVisualization : SingleValueLabelsVisualizationBase<DoughnutChartVisualizationSettings>
    {
        internal DoughnutChartVisualization() : this(null) { }

        public DoughnutChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
