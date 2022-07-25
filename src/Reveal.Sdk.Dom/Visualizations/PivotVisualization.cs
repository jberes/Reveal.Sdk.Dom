using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class PivotVisualization : TabularVisualizationBase<PivotVisualizationSettings>, IValues, IRows, IColumns
    {
        internal PivotVisualization() : this(null) { }
        public PivotVisualization(DataSourceItem dataSourceItem) : base(string.Empty, dataSourceItem) { }
        public PivotVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) 
        {
            //this is a workaround because the json schemea has this property on the VisualizationDataSpec and not on the VisualizationSettings where it belongs
            Settings._visualizationDataSpec = VisualizationDataSpec;
        }

        [JsonIgnore]
        public List<DimensionColumn> Columns { get { return VisualizationDataSpec.Columns; } }

        [JsonIgnore]
        public List<DimensionColumn> Rows { get { return VisualizationDataSpec.Rows; } }

        [JsonIgnore]
        public List<MeasureColumn> Values { get { return VisualizationDataSpec.Values; } }

        [JsonProperty(Order = 7)]
        PivotVisualizationDataSpec VisualizationDataSpec { get; set; } = new PivotVisualizationDataSpec();
    }
}