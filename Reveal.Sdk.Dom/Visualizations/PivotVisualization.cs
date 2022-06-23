using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class PivotVisualization : Visualization<PivotVisualizationSettings, PivotVisualizationDataSpec>
    {
        public PivotVisualization() : base() { }

        public PivotVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
