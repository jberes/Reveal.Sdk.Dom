using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class SparklineVisualization : SparklineVisualizationBase<SparklineVisualizationSettings>
    {
        internal SparklineVisualization() : this(null) { }

        public SparklineVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        public SparklineVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }
    }

}
