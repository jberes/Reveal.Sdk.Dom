using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class IndicatorVisualizationBase<TSettings> : Visualization<TSettings, IndicatorVisualizationDataSpec>
        where TSettings : VisualizationSettings, new()
    {
        protected IndicatorVisualizationBase(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        [JsonIgnore]
        public DimensionColumnSpec Date 
        { 
            get { return GetVisualizationDataSpec().Date; } 
            set { GetVisualizationDataSpec().Date = value; } 
        }

        [JsonIgnore]
        public IndicatorVisualizationType IndicatorType
        {
            get { return GetVisualizationDataSpec().IndicatorType; }
            set { GetVisualizationDataSpec().IndicatorType = value; }
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
    }
}