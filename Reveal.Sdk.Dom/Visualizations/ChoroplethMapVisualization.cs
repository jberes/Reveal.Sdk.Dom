using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class ChoroplethMapVisualization : TabularVisualizationBase<ChoroplethMapVisualizationSettings>, IValues
    {
        internal ChoroplethMapVisualization() : this(null) { }
        public ChoroplethMapVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public ChoroplethMapVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        ChoroplethMapVisualizationDataSpec VisualizationDataSpec { get; set; } = new ChoroplethMapVisualizationDataSpec();

        [JsonIgnore]
        public string Map
        {
            get { return Settings.Region; }
            set { Settings.Region = value; }
        }

        [JsonIgnore]
        public List<DimensionColumnSpec> Locations
        {
            get { return VisualizationDataSpec.Rows; }
        }

        [JsonIgnore]
        public DimensionColumnSpec MapColor
        {
            get { return VisualizationDataSpec.MapColor; }
            set { VisualizationDataSpec.MapColor = value; }
        }

        [JsonIgnore]
        public List<MeasureColumnSpec> Values
        {
            get { return VisualizationDataSpec.Value; }
        }
    }
}
