using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class TimeSeriesVisualization : Visualization<ChartVisualizationSettings>, IValues, ICategory
    {
        internal TimeSeriesVisualization() : this(null) { }
        public TimeSeriesVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
        public TimeSeriesVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        TimeSeriesVisualizationDataSpec VisualizationDataSpec { get; set; } = new TimeSeriesVisualizationDataSpec();

        //todo: this is supposed to have a date, but there is no date property on the viz data spec, is this using the rows collection?
        //can there only be one?
        //[JsonIgnore]
        //public DimensionColumnSpec Date 
        //{ 
        //    get { return VisualizationDataSpec.Date; }  
        //}

        [JsonIgnore]
        public List<MeasureColumnSpec> Values { get { return VisualizationDataSpec.Values; } }

        [JsonIgnore] 
        public DimensionColumnSpec Category 
        { 
            get { return VisualizationDataSpec.Category; }
            set { VisualizationDataSpec.Category = value; }
        }
    }
}
