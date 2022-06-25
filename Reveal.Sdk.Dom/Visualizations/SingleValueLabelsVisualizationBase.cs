using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Serialization.Converters;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class SingleValueLabelsVisualizationBase<TSettings> : Visualization<TSettings>
        where TSettings : VisualizationSettings, new()
    {
        protected SingleValueLabelsVisualizationBase(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        [JsonIgnore]
        public List<DimensionColumnSpec> Labels { get { return VisualizationDataSpec.Rows; } }

        [JsonIgnore]
        public List<MeasureColumnSpec> Values { get { return VisualizationDataSpec.Value; } }

        [JsonProperty(Order = 7)]
        SingleValueLabelsVisualizationDataSpec VisualizationDataSpec { get; set; } = new SingleValueLabelsVisualizationDataSpec();
    }
}