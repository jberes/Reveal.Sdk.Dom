using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class ComboChartVisualization : TabularVisualizationBase<ComboChartVisualizationSettings>, ILabels
    {
        internal ComboChartVisualization() : this(null) { }
        public ComboChartVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public ComboChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonProperty(Order = 7)]
        CompositeChartVisualizationDataSpec VisualizationDataSpec { get; set; } = new CompositeChartVisualizationDataSpec();

        [JsonIgnore]
        public List<MeasureColumnSpec> Chart1 { get { return VisualizationDataSpec.Chart1; } }

        [JsonIgnore]
        public List<MeasureColumnSpec> Chart2 { get { return VisualizationDataSpec.Chart2; } }

        [JsonIgnore]
        public List<DimensionColumnSpec> Labels { get { return VisualizationDataSpec.Rows; } }
    }
}
