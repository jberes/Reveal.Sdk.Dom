using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    //todo: should this be named DYI or Dyi? - update setting class acccordingly
    public class DiyVisualization : TabularVisualizationBase<DIYVisualizationSettings>, IRows, IValues, IColumns
    {
        internal DiyVisualization() : this(null) { }
        public DiyVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public DiyVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        PivotVisualizationDataSpec VisualizationDataSpec { get; set; } = new PivotVisualizationDataSpec();

        [JsonIgnore]
        public List<DimensionColumnSpec> Rows { get { return VisualizationDataSpec.Rows; } }

        [JsonIgnore]
        public List<MeasureColumnSpec> Values { get { return VisualizationDataSpec.Values; } }

        [JsonIgnore]
        public List<DimensionColumnSpec> Columns { get { return VisualizationDataSpec.Columns; } }

        [JsonIgnore]
        public string Url
        {
            get { return Settings.Url; }
            set { Settings.Url = value; }
        }
    }
}
