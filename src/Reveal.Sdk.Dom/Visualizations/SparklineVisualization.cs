using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The sparkline visualization is used to show data in table form along with a small-scale chart that uses a line or area series to show trends in a collection of values.
    /// </summary>
    public sealed class SparklineVisualization : Visualization<SparklineVisualizationSettings>, IDate, IValues, ICategories
    {
        internal SparklineVisualization() : this(null) { }

        /// <summary>
        /// Creates a sparkline visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public SparklineVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a sparkline visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public SparklineVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem)
        {
            Settings._visualizationDataSpec = VisualizationDataSpec;
            ChartType = ChartType.Sparkline;
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
        internal SparklineVisualizationDataSpec VisualizationDataSpec { get; set; } = new SparklineVisualizationDataSpec();
    }
}