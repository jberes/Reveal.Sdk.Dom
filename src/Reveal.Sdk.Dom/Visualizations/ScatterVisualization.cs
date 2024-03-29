using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The scatter visualization is used to show the relationship among items in distinct series of data or to plot data items using numeric x and y coordinates. These charts draw attention to uneven intervals or clusters of data. 
    /// </summary>
    public sealed class ScatterVisualization : TabularVisualizationBase<ScatterVisualizationSettings>, ILabels, IAxis
    {
        internal ScatterVisualization() : this(null) { }

        /// <summary>
        /// Creates a scatter visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public ScatterVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a scatter visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public ScatterVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { ChartType = ChartType.Scatter; }

        [JsonProperty(Order = 7)]
        ScatterVisualizationDataSpec VisualizationDataSpec { get; set; } = new ScatterVisualizationDataSpec();

        [JsonIgnore]
        public List<DimensionColumn> Labels { get { return VisualizationDataSpec.Rows; } }

        [JsonIgnore]
        public List<MeasureColumn> XAxes { get { return VisualizationDataSpec.XAxis; } }

        [JsonIgnore]
        public List<MeasureColumn> YAxes { get { return VisualizationDataSpec.YAxis; } }
    }
}
