using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The scatter map visualization is used to display geo-spatial data using points or markers in a geographic context. This type of visualization is often used to render a collection of geographic locations such as cities, airports, earthquakes, or points of interests.
    /// </summary>
    public sealed class ScatterMapVisualization : TabularVisualizationBase<ScatterMapVisualizationSettings>, ILabel, IMap
    {
        internal ScatterMapVisualization() : this(null) { }

        /// <summary>
        /// Creates a scatter map visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public ScatterMapVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a scatter map visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public ScatterMapVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { ChartType = ChartType.ScatterMap; }

        [JsonProperty(Order = 7)]
        internal ScatterMapVisualizationDataSpec VisualizationDataSpec { get; set; } = new ScatterMapVisualizationDataSpec();

        [JsonIgnore]
        public DimensionColumn Label
        {
            get { return VisualizationDataSpec.Label; }
            set { VisualizationDataSpec.Label = value; }
        }

        [JsonIgnore]
        public string Map
        {
            get { return Settings.Region; }
            set { Settings.Region = value; }
        }

        [JsonIgnore]
        public DimensionColumn Latitude
        {
            get { return VisualizationDataSpec.Location; }
            set { VisualizationDataSpec.Location = value; }
        }

        [JsonIgnore]
        public DimensionColumn Longitude
        {
            get { return VisualizationDataSpec.Longitude; }
            set { VisualizationDataSpec.Longitude = value; }
        }

        [JsonIgnore]
        public List<MeasureColumn> MapColor
        {
            get { return VisualizationDataSpec.MapColor; }
            set { VisualizationDataSpec.MapColor = value; }
        }

        [JsonIgnore]
        public DimensionColumn MapColorCategory
        {
            get { return VisualizationDataSpec.MapColorCategory; }
            set
            {
                VisualizationDataSpec.IsColorByValue = false;
                VisualizationDataSpec.MapColorCategory = value;
            }
        }

        [JsonIgnore]
        public List<MeasureColumn> BubbleRadius
        {
            get { return VisualizationDataSpec.Radius; }
            set { VisualizationDataSpec.Radius = value; }
        }
    }
}
