using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class BubbleVisualization : Visualization<BubbleVisualizationSettings>
    {
        internal BubbleVisualization() : this(null) { }
        public BubbleVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
        public BubbleVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        //todo: implement

        [JsonProperty(Order = 7)]
        BubbleVisualizationDataSpec VisualizationDataSpec { get; set; } = new BubbleVisualizationDataSpec();
    }
}
