using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class PivotVisualization : PivotVisualizationBase<PivotVisualizationSettings>
    {
        internal PivotVisualization() : this(null) { }

        public PivotVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
