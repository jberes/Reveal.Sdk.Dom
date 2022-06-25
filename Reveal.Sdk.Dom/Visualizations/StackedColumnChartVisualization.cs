using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class StackedColumnChartVisualization : CategoryVisualizationBase<StackedColumnChartVisualizationSettings>
    {
        internal StackedColumnChartVisualization() : this(null) { }

        public StackedColumnChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
