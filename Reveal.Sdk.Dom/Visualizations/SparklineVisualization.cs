using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class SparklineVisualization : Visualization<SparklineVisualizationSettings, SparklineVisualizationDataSpec>
    {
        public SparklineVisualization() : base() { }

        public SparklineVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }

}
