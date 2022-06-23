using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class IndicatorVisualization : Visualization<IndicatorVisualizationSettings, IndicatorVisualizationDataSpec>
    {
        internal IndicatorVisualization() : this(null) { }

        public IndicatorVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        [JsonIgnore]
        public DimensionColumnSpec Date { get { return VisualizationDataSpec.Date; } set { VisualizationDataSpec.Date = value; } }

        [JsonIgnore]
        public IndicatorVisualizationType IndicatorType { get { return VisualizationDataSpec.IndicatorType; } }

        [JsonIgnore]
        public List<MeasureColumnSpec> Value { get { return VisualizationDataSpec.Value; } }
    }
}
