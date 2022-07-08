using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class ImageVisualization : TabularVisualizationBase<AssetVisualizationSettings>
    {
        internal ImageVisualization() : this(null) { }
        public ImageVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public ImageVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        AssetVisualizationDataSpec VisualizationDataSpec { get; set; } = new AssetVisualizationDataSpec();

        [JsonIgnore]
        public TabularColumnSpec UrlColumn 
        { 
            get { return VisualizationDataSpec.UrlColumn; } 
            set { VisualizationDataSpec.UrlColumn = value; }
        }
    }
}
