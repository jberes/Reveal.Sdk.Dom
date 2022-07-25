using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class TreeMapVisualization : TabularVisualizationBase<TreeMapVisualizationSettings>, ILabels, IValues
    {
        internal TreeMapVisualization() : this(null) { }
        public TreeMapVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public TreeMapVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        TreeMapVisualizationDataSpec VisualizationDataSpec { get; set; } = new TreeMapVisualizationDataSpec();

        [JsonIgnore]
        public List<DimensionColumn> Labels { get { return VisualizationDataSpec.Rows; } }
        
        [JsonIgnore]
        public List<MeasureColumn> Values { get { return VisualizationDataSpec.Value; } }
    }
}
