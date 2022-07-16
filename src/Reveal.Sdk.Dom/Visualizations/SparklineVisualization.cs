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
            //this is a workaround because the json schemea has properties on the VisualizationDataSpec and not on the VisualizationSettings where they belong
            Settings._visualizationDataSpec = VisualizationDataSpec;
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

        [JsonProperty(Order = 7)]
        SparklineVisualizationDataSpec VisualizationDataSpec { get; set; } = new SparklineVisualizationDataSpec();
    }
}