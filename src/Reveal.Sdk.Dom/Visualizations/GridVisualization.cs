using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The grid view visualization is used for displaying data which presents the information in a table.
    /// </summary>
    public sealed class GridVisualization : TabularVisualizationBase<GridVisualizationSettings>, ITabularColumns
    {
        internal GridVisualization() : this(null) { }

        /// <summary>
        /// Creates a grid visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public GridVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a grid visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public GridVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonIgnore]
        public List<TabularColumn> Columns { get { return VisualizationDataSpec.Columns; } }

        [JsonProperty(Order = 7)]
        GridVisualizationDataSpec VisualizationDataSpec { get; set; } = new GridVisualizationDataSpec();
    }
}
