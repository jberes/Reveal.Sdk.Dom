using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class ChoroplethMapVisualization : Visualization<ChoroplethMapVisualizationSettings>
    {
        internal ChoroplethMapVisualization() : this(null) { }
        public ChoroplethMapVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
        public ChoroplethMapVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        //todo: implement

        [JsonProperty(Order = 7)]
        ChoroplethMapVisualizationDataSpec VisualizationDataSpec { get; set; } = new ChoroplethMapVisualizationDataSpec();
    }
}
