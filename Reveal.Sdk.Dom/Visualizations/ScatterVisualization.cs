using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class ScatterVisualization : Visualization<ScatterVisualizationSettings>
    {
        internal ScatterVisualization() : this(null) { }
        public ScatterVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
        public ScatterVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        //todo: implement

        [JsonProperty(Order = 7)]
        ScatterVisualizationDataSpec VisualizationDataSpec { get; set; } = new ScatterVisualizationDataSpec();
    }
}
