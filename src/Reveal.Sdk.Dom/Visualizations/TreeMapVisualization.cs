using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The treemap visualization is used to display hierarchical data as a set of nested rectangles. Rectangles of each level are of different sizes and colors.
    /// </summary>
    public sealed class TreeMapVisualization : TabularVisualizationBase<TreeMapVisualizationSettings>, ILabels, IValues
    {
        internal TreeMapVisualization() : this(null) { }

        /// <summary>
        /// Creates a treemap visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public TreeMapVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a treemap visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public TreeMapVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        TreeMapVisualizationDataSpec VisualizationDataSpec { get; set; } = new TreeMapVisualizationDataSpec();

        [JsonIgnore]
        public List<DimensionColumn> Labels { get { return VisualizationDataSpec.Rows; } }
        
        [JsonIgnore]
        public List<MeasureColumn> Values { get { return VisualizationDataSpec.Value; } }
    }
}
