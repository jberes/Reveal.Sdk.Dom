using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The custom visualizion is used to support visualizations not supported out of the box. This type of visualization uses a web view to pass data to the visualization for display.
    /// </summary>
    public sealed class CustomVisualization : TabularVisualizationBase<CustomVisualizationSettings>, IRows, IValues, IColumns
    {
        internal CustomVisualization() : this(null) { }

        /// <summary>
        /// Creates a custom visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public CustomVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a custom visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public CustomVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        PivotVisualizationDataSpec VisualizationDataSpec { get; set; } = new PivotVisualizationDataSpec();

        [JsonIgnore]
        public List<DimensionColumn> Rows { get { return VisualizationDataSpec.Rows; } }

        [JsonIgnore]
        public List<MeasureColumn> Values { get { return VisualizationDataSpec.Values; } }

        [JsonIgnore]
        public List<DimensionColumn> Columns { get { return VisualizationDataSpec.Columns; } }

        [JsonIgnore]
        public string Url
        {
            get { return Settings.Url; }
            set { Settings.Url = value; }
        }
    }
}
