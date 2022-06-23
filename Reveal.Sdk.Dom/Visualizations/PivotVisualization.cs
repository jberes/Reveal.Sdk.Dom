using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class PivotVisualization : Visualization<PivotVisualizationSettings, PivotVisualizationDataSpec>
    {
        internal PivotVisualization() : this(null) { }

        public PivotVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
