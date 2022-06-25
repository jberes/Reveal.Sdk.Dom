using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class LineChartVisualization : CategoryVisualizationBase<LineChartVisualizationSettings>
    {
        internal LineChartVisualization() : this(null) { }

        public LineChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
