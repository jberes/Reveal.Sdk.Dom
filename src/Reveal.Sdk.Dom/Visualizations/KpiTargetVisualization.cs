using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class KpiTargetVisualization : TabularVisualizationBase<KpiTargetVisualizationSettings>, ITargets, IDate, IValues, ICategories
    {
        internal KpiTargetVisualization() : this(null) { }
        public KpiTargetVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public KpiTargetVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) 
        {
            Settings.VisualizationDataSpec = VisualizationDataSpec;
        }

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