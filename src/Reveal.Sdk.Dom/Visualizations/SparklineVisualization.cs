using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class SparklineVisualization : TabularVisualizationBase<SparklineVisualizationSettings>, IDate, IValues, ICategories
    {
        internal SparklineVisualization() : this(null) { }
        public SparklineVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public SparklineVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem)
        {
            Settings._visualizationDataSpec = VisualizationDataSpec;
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
        SparklineVisualizationDataSpec VisualizationDataSpec { get; set; } = new SparklineVisualizationDataSpec();
    }
}