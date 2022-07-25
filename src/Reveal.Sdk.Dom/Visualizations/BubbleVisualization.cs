using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class BubbleVisualization : TabularVisualizationBase<BubbleVisualizationSettings>, ILabels, IAxis
    {
        internal BubbleVisualization() : this(null) { }
        public BubbleVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public BubbleVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

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
