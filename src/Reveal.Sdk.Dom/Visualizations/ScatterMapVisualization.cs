using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class ScatterMapVisualization : TabularVisualizationBase<ScatterMapVisualizationSettings>, ILabel, IMap
    {
        internal ScatterMapVisualization() : this(null) { }
        public ScatterMapVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public ScatterMapVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        ScatterMapVisualizationDataSpec VisualizationDataSpec { get; set; } = new ScatterMapVisualizationDataSpec();

        [JsonIgnore]
        public DimensionColumnSpec Label 
        { 
            get { return VisualizationDataSpec.Label; }
            set { VisualizationDataSpec.Label = value; }
        }

        [JsonIgnore]
        public string Map
        {
            get { return Settings.Region; }
            set { Settings.Region = value; }
        }

        [JsonIgnore]
        public DimensionColumnSpec Latitude
        {
            get { return VisualizationDataSpec.Location; }
            set { VisualizationDataSpec.Location = value; }
        }

        [JsonIgnore]
        public DimensionColumnSpec Longitude
        {
            get { return VisualizationDataSpec.Longitude; }
            set { VisualizationDataSpec.Longitude = value; }
        }
    }
}
