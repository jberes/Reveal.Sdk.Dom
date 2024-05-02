using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The text view visualization is used to display information that follows a key-value pattern. It only displays the first row of data paired with the column's label.
    /// </summary>
    public sealed class TextViewVisualization : Visualization<SingleRowVisualizationSettings>, ITabularColumns
    {
        internal TextViewVisualization() : this(null) { }

        /// <summary>
        /// Creates a text view visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public TextViewVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a text view visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public TextViewVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { ChartType = ChartType.TextView; }

        [JsonProperty(Order = 7)]
        GridVisualizationDataSpec VisualizationDataSpec { get; set; } = new GridVisualizationDataSpec();

        [JsonIgnore]
        public List<TabularColumn> Columns { get { return VisualizationDataSpec.Columns; } }
    }
}
