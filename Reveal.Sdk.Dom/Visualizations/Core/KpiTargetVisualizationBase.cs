using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class KpiTargetVisualizationBase<TSettings> : Visualization<TSettings, KpiTargetVisualizationDataSpec>
        where TSettings : VisualizationSettings, new()
    {
        protected KpiTargetVisualizationBase(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        [JsonIgnore]
        public DimensionColumnSpec Date
        {
            get { return GetVisualizationDataSpec().Date; }
            set { GetVisualizationDataSpec().Date = value; }
        }

        [JsonIgnore]
        public List<MeasureColumnSpec> Values
        {
            get { return GetVisualizationDataSpec().Value; }
        }

        //todo: confirm that the category is stored as rows
        [JsonIgnore]
        public List<DimensionColumnSpec> Categories
        {
            get { return GetVisualizationDataSpec().Rows; }
        }

        [JsonIgnore]
        public List<MeasureColumnSpec> Target
        {
            get { return GetVisualizationDataSpec().Target; }
        }
    }
}