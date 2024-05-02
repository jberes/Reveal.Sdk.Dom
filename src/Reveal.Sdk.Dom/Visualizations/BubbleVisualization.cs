using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The bubble chart visualization is a type of scatter chart that show markers with variable scaling to represent the relationship among items in several distinct series of data or to plot data items using x and y coordinates. These coordinates of the data point are determined by two numeric data columns. The bubble chart draws attention to uneven intervals or clusters of data. This chart is often used to plot scientific data, and can highlight the deviation of collected data from predicted results.
    /// </summary>
    public sealed class BubbleVisualization : Visualization<BubbleVisualizationSettings>, ILabels, IAxis
    {
        internal BubbleVisualization() : this(null) { }

        /// <summary>
        /// Creates a bubble chart visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public BubbleVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a bubble chart visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public BubbleVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { ChartType = ChartType.Bubble; }

        [JsonProperty(Order = 7)]
        BubbleVisualizationDataSpec VisualizationDataSpec { get; set; } = new BubbleVisualizationDataSpec();

        [JsonIgnore]
        public List<DimensionColumn> Labels { get { return VisualizationDataSpec.Rows; } }

        [JsonIgnore]
        public List<MeasureColumn> XAxes { get { return VisualizationDataSpec.XAxis; } }

        [JsonIgnore]
        public List<MeasureColumn> YAxes { get { return VisualizationDataSpec.YAxis; } }

        [JsonIgnore]
        public List<MeasureColumn> Radius { get { return VisualizationDataSpec.Radius; }}
    }
}
