using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class KpiTimeVisualization : TabularVisualizationBase<KpiTimeVisualizationSettings>, IDate, IValues, ICategories
    {
        internal KpiTimeVisualization() : this(null) { }
        public KpiTimeVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public KpiTimeVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem)
        {
            Settings.VisualizationDataSpec = VisualizationDataSpec;
        }

        [JsonIgnore]
        public DimensionColumn Date 
        { 
            get { return VisualizationDataSpec.Date; } 
            set { VisualizationDataSpec.Date = value; } 
        }

        [JsonIgnore]
        public List<MeasureColumn> Values 
        { 
            get { return VisualizationDataSpec.Value; } 
        }

        [JsonIgnore]
        public List<DimensionColumn> Categories 
        {
            get { return VisualizationDataSpec.Rows; }             
        }

        [JsonProperty(Order = 7)]
        IndicatorVisualizationDataSpec VisualizationDataSpec { get; set; } = new IndicatorVisualizationDataSpec();
    }
}