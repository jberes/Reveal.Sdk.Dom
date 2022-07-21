using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class ScatterMapVisualization : TabularVisualizationBase<ScatterMapVisualizationSettings>, ILabel, IMap
    {
        internal ScatterMapVisualization() : this(null) { }
        public ScatterMapVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public ScatterMapVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        internal ScatterMapVisualizationDataSpec VisualizationDataSpec { get; set; } = new ScatterMapVisualizationDataSpec();

        [JsonIgnore]
        public DimensionColumn Label
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
        public DimensionColumn Latitude
        {
            get { return VisualizationDataSpec.Location; }
            set { VisualizationDataSpec.Location = value; }
        }

        [JsonIgnore]
        public DimensionColumn Longitude
        {
            get { return VisualizationDataSpec.Longitude; }
            set { VisualizationDataSpec.Longitude = value; }
        }

        [JsonIgnore]
        public List<MeasureColumn> MapColor
        {
            get { return VisualizationDataSpec.MapColor; }
            set { VisualizationDataSpec.MapColor = value; }
        }

        [JsonIgnore]
        public DimensionColumn MapColorCategory
        {
            get { return VisualizationDataSpec.MapColorCategory; }
            set
            {
                VisualizationDataSpec.IsColorByValue = false;
                VisualizationDataSpec.MapColorCategory = value;
            }
        }

        [JsonIgnore]
        public List<MeasureColumn> BubbleRadius
        {
            get { return VisualizationDataSpec.Radius; }
            set { VisualizationDataSpec.Radius = value; }
        }
    }
}
