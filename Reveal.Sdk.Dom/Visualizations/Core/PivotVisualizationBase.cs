using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class PivotVisualizationBase<TSettings> : Visualization<TSettings, PivotVisualizationDataSpec>
        where TSettings : VisualizationSettings, new()
    {
        protected PivotVisualizationBase(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        [JsonIgnore]
        public List<DimensionColumnSpec> Columns { get { return GetVisualizationDataSpec().Columns; } }

        [JsonIgnore]
        public List<DimensionColumnSpec> Rows { get { return GetVisualizationDataSpec().Rows; } }

        [JsonIgnore]
        public List<MeasureColumnSpec> Values { get { return GetVisualizationDataSpec().Values; } }

        [JsonIgnore]
        public bool ShowGrandTotals 
        { 
            get { return GetVisualizationDataSpec().ShowGrandTotals; }
            set { GetVisualizationDataSpec().ShowGrandTotals = value; }
        }
    }
}