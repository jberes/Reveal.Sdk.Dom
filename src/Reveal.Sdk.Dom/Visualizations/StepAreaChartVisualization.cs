using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class StepAreaChartVisualization : CategoryVisualizationBase<StepAreaChartVisualizationSettings>
    {
        internal StepAreaChartVisualization() : this(null) { }

        public StepAreaChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        public StepAreaChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }
}
