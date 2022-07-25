using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class CustomVisualization : TabularVisualizationBase<CustomVisualizationSettings>, IRows, IValues, IColumns
    {
        internal CustomVisualization() : this(null) { }
        public CustomVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public CustomVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        PivotVisualizationDataSpec VisualizationDataSpec { get; set; } = new PivotVisualizationDataSpec();

        [JsonIgnore]
        public List<DimensionColumn> Rows { get { return VisualizationDataSpec.Rows; } }

        [JsonIgnore]
        public List<MeasureColumn> Values { get { return VisualizationDataSpec.Values; } }

        [JsonIgnore]
        public List<DimensionColumn> Columns { get { return VisualizationDataSpec.Columns; } }

        [JsonIgnore]
        public string Url
        {
            get { return Settings.Url; }
            set { Settings.Url = value; }
        }
    }
}
