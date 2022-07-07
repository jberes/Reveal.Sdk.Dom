using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class ScatterMapVisualization : TabularVisualizationBase<ScatterMapVisualizationSettings>, ILabel
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

        //todo: how can we make it easy to populate this?
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
