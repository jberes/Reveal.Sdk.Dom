using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class IndicatorVisualization : Visualization<IndicatorVisualizationSettings, IndicatorVisualizationDataSpec>
    {
        public IndicatorVisualization() : base() { }

        public IndicatorVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
