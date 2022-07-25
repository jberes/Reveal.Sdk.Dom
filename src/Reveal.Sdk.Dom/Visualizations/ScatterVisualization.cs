using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class ScatterVisualization : TabularVisualizationBase<ScatterVisualizationSettings>, ILabels, IAxis
    {
        internal ScatterVisualization() : this(null) { }
        public ScatterVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public ScatterVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        ScatterVisualizationDataSpec VisualizationDataSpec { get; set; } = new ScatterVisualizationDataSpec();

        [JsonIgnore]
        public List<DimensionColumn> Labels { get { return VisualizationDataSpec.Rows; } }

        [JsonIgnore]
        public List<MeasureColumn> XAxes { get { return VisualizationDataSpec.XAxis; } }

        [JsonIgnore]
        public List<MeasureColumn> YAxes { get { return VisualizationDataSpec.YAxis; } }
    }
}
