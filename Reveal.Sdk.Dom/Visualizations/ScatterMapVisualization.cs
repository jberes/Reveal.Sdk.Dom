using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class ScatterMapVisualization : Visualization<ScatterMapVisualizationSettings>
    {
        internal ScatterMapVisualization() : this(null) { }
        public ScatterMapVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
        public ScatterMapVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        //todo: implement

        [JsonProperty(Order = 7)]
        ScatterMapVisualizationDataSpec VisualizationDataSpec { get; set; } = new ScatterMapVisualizationDataSpec();
    }
}
