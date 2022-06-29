using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class PieChartVisualization : SingleValueLabelsVisualizationBase<PieChartVisualizationSettings>
    {
        internal PieChartVisualization() : this(null) { }
        public PieChartVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public PieChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
