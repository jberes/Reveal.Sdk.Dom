using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class StepLineChartVisualization : CategoryVisualizationBase<StepLineChartVisualizationSettings>
    {
        internal StepLineChartVisualization() : this(null) { }

        public StepLineChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        public StepLineChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
