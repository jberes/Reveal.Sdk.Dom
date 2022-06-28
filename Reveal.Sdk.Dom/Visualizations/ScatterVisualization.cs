using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class ScatterVisualization : Visualization<ScatterVisualizationSettings>, ILabels, IAxis
    {
        internal ScatterVisualization() : this(null) { }
        public ScatterVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
        public ScatterVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        ScatterVisualizationDataSpec VisualizationDataSpec { get; set; } = new ScatterVisualizationDataSpec();

        [JsonIgnore]
        public List<DimensionColumnSpec> Labels { get { return VisualizationDataSpec.Rows; } }

        [JsonIgnore]
        public List<MeasureColumnSpec> XAxis { get { return VisualizationDataSpec.XAxis; } }

        [JsonIgnore]
        public List<MeasureColumnSpec> YAxis { get { return VisualizationDataSpec.YAxis; } }
    }
}
