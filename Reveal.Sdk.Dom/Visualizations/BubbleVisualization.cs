using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class BubbleVisualization : Visualization<BubbleVisualizationSettings>, ILabels, IAxis
    {
        internal BubbleVisualization() : this(null) { }
        public BubbleVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
        public BubbleVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        BubbleVisualizationDataSpec VisualizationDataSpec { get; set; } = new BubbleVisualizationDataSpec();

        [JsonIgnore]
        public List<DimensionColumnSpec> Labels { get { return VisualizationDataSpec.Rows; } }

        [JsonIgnore]
        public List<MeasureColumnSpec> XAxis { get { return VisualizationDataSpec.XAxis; } }

        [JsonIgnore]
        public List<MeasureColumnSpec> YAxis { get { return VisualizationDataSpec.YAxis; } }

        [JsonIgnore]
        public List<MeasureColumnSpec> Radius { get { return VisualizationDataSpec.Radius; }}
    }
}
