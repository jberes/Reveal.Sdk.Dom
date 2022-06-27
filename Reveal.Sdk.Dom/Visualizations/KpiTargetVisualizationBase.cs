using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class KpiTargetVisualizationBase<TSettings> : Visualization<TSettings>, IKpiTargetVisualization
        where TSettings : VisualizationSettings, new()
    {
        protected KpiTargetVisualizationBase(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        protected KpiTargetVisualizationBase(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        [JsonIgnore]
        public DimensionColumnSpec Date
        {
            get { return VisualizationDataSpec.Date; }
            set { VisualizationDataSpec.Date = value; }
        }

        [JsonIgnore]
        public List<MeasureColumnSpec> Values
        {
            get { return VisualizationDataSpec.Value; }
        }

        //todo: confirm that the category is stored as rows
        [JsonIgnore]
        public List<DimensionColumnSpec> Categories
        {
            get { return VisualizationDataSpec.Rows; }
        }

        [JsonIgnore]
        public List<MeasureColumnSpec> Targets
        {
            get { return VisualizationDataSpec.Target; }
        }

        [JsonProperty(Order = 7)]
        IndicatorTargetVisualizationDataSpec VisualizationDataSpec { get; set; } = new IndicatorTargetVisualizationDataSpec();
    }
}