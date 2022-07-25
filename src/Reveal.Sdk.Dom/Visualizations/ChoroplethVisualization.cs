using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class ChoroplethVisualization : TabularVisualizationBase<ChoroplethVisualizationSettings>, IValues, IMap
    {
        internal ChoroplethVisualization() : this(null) { }
        public ChoroplethVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public ChoroplethVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        ChoroplethVisualizationDataSpec VisualizationDataSpec { get; set; } = new ChoroplethVisualizationDataSpec();

        [JsonIgnore]
        public string Map
        {
            get { return Settings.Region; }
            set { Settings.Region = value; }
        }

        [JsonIgnore]
        public List<DimensionColumn> Locations
        {
            get { return VisualizationDataSpec.Rows; }
        }

        [JsonIgnore]
        public DimensionColumn MapColor
        {
            get { return VisualizationDataSpec.MapColor; }
            set { VisualizationDataSpec.MapColor = value; }
        }

        [JsonIgnore]
        public List<MeasureColumn> Values
        {
            get { return VisualizationDataSpec.Value; }
        }
    }
}
