using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class SplineChartVisualization : CategoryVisualizationBase<SplineChartVisualizationSettings>
    {
        internal SplineChartVisualization() : this(null) { }

        public SplineChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        public SplineChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
