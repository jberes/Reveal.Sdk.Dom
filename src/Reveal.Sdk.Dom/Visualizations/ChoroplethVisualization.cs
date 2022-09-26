using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The choropleth visualization is used to display geo-spatial data using shape polygons in a geographic context. This type of visualization is often used to render shapes of countries or regions defined by geographic locations.
    /// </summary>
    public sealed class ChoroplethVisualization : TabularVisualizationBase<ChoroplethVisualizationSettings>, IValues, IMap
    {
        internal ChoroplethVisualization() : this(null) { }

        /// <summary>
        /// Creates a choropleth visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public ChoroplethVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a choropleth visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public ChoroplethVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        ChoroplethVisualizationDataSpec VisualizationDataSpec { get; set; } = new ChoroplethVisualizationDataSpec();

        [JsonIgnore]
        public string Map
        {
            get { return Settings.Region; }
            set { Settings.Region = value; }
        }

        [JsonIgnore]
        public List<DimensionColumn> Locations
        {
            get { return VisualizationDataSpec.Rows; }
        }

        [JsonIgnore]
        public DimensionColumn MapColor
        {
            get { return VisualizationDataSpec.MapColor; }
            set { VisualizationDataSpec.MapColor = value; }
        }

        [JsonIgnore]
        public List<MeasureColumn> Values
        {
            get { return VisualizationDataSpec.Value; }
        }
    }
}
