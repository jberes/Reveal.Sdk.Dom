using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class PivotVisualizationBase<TSettings> : Visualization<TSettings>, IValues, IRows, IColumns
        where TSettings : VisualizationSettings, new()
    {
        protected PivotVisualizationBase(DataSourceItem dataSourceItem) : base(string.Empty, dataSourceItem) { }
        protected PivotVisualizationBase(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonIgnore]
        public List<DimensionColumnSpec> Columns { get { return VisualizationDataSpec.Columns; } }

        [JsonIgnore]
        public List<DimensionColumnSpec> Rows { get { return VisualizationDataSpec.Rows; } }

        [JsonIgnore]
        public List<MeasureColumnSpec> Values { get { return VisualizationDataSpec.Values; } }

        [JsonIgnore]
        public bool ShowGrandTotals
        {
            get { return VisualizationDataSpec.ShowGrandTotals; }
            set { VisualizationDataSpec.ShowGrandTotals = value; }
        }

        [JsonProperty(Order = 7)]
        PivotVisualizationDataSpec VisualizationDataSpec { get; set; } = new PivotVisualizationDataSpec();
    }
}