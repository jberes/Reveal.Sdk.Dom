using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class TimeSeriesVisualization : TabularVisualizationBase<TimeSeriesVisualizationSettings>, IDate, IValues, ICategory
    {
        internal TimeSeriesVisualization() : this(null) { }
        public TimeSeriesVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public TimeSeriesVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        TimeSeriesVisualizationDataSpec VisualizationDataSpec { get; set; } = new TimeSeriesVisualizationDataSpec();

        [JsonIgnore]
        public List<MeasureColumn> Values { get { return VisualizationDataSpec.Values; } }

        [JsonIgnore]
        public DimensionColumn Category
        {
            get { return VisualizationDataSpec.Category; }
            set { VisualizationDataSpec.Category = value; }
        }

        [JsonIgnore]
        public DimensionColumn Date
        {
            get
            {
                if (VisualizationDataSpec.Rows.Count > 0)
                    return VisualizationDataSpec.Rows[0];
                else 
                    return null;
            }
            set
            {
                VisualizationDataSpec.Rows.Clear();
                VisualizationDataSpec.Rows.Add(value);
            }
        }
    }
}
