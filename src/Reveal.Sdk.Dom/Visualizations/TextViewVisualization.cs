using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class TextViewVisualization : TabularVisualizationBase<SingleRowVisualizationSettings>, ITabularColumns
    {
        internal TextViewVisualization() : this(null) { }
        public TextViewVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public TextViewVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        GridVisualizationDataSpec VisualizationDataSpec { get; set; } = new GridVisualizationDataSpec();

        [JsonIgnore]
        public List<TabularColumn> Columns { get { return VisualizationDataSpec.Columns; } }
    }
}
