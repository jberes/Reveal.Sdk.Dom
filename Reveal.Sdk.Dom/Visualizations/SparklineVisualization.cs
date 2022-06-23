using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class SparklineVisualization : Visualization<SparklineVisualizationSettings, SparklineVisualizationDataSpec>
    {
        internal SparklineVisualization() : this(null) { }

        public SparklineVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }

}
