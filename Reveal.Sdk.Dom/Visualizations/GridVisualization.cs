using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class GridVisualization : TabularVisualizationBase<GridVisualizationSettings>, ITabularColumns
    {
        internal GridVisualization() : this(null) { }
        public GridVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public GridVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonIgnore]
        public List<TabularColumnSpec> Columns { get { return VisualizationDataSpec.Columns; } }

        [JsonProperty(Order = 7)]
        GridVisualizationDataSpec VisualizationDataSpec { get; set; } = new GridVisualizationDataSpec();
    }
}
