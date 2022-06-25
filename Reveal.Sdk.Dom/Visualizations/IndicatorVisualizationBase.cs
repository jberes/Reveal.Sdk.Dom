using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class IndicatorVisualizationBase<TSettings> : Visualization<TSettings>
        where TSettings : VisualizationSettings, new()
    {
        protected IndicatorVisualizationBase(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        [JsonIgnore]
        public DimensionColumnSpec Date 
        { 
            get { return VisualizationDataSpec.Date; } 
            set { VisualizationDataSpec.Date = value; } 
        }

        [JsonIgnore]
        public IndicatorVisualizationType IndicatorType
        {
            get { return VisualizationDataSpec.IndicatorType; }
            set { VisualizationDataSpec.IndicatorType = value; }
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

        [JsonProperty(Order = 7)]
        IndicatorVisualizationDataSpec VisualizationDataSpec { get; set; } = new IndicatorVisualizationDataSpec();
    }
}