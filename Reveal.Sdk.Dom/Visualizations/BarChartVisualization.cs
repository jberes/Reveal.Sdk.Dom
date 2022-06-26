using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class BarChartVisualization : CategoryVisualizationBase<BarChartVisualizationSettings>
    {
        internal BarChartVisualization() : this(null) { }

        public BarChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        public BarChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
