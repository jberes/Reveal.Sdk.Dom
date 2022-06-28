using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class TreeMapVisualization : Visualization<TreeMapVisualizationSettings>
    {
        internal TreeMapVisualization() : this(null) { }
        public TreeMapVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
        public TreeMapVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        //todo: implement

        [JsonProperty(Order = 7)]
        TreeMapVisualizationDataSpec VisualizationDataSpec { get; set; } = new TreeMapVisualizationDataSpec();
    }
}
