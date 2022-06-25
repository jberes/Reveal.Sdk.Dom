using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class SingleGaugeVisualizationBase<TSettings> : Visualization<TSettings>
        where TSettings : VisualizationSettings, new()
    {
        protected SingleGaugeVisualizationBase(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        [JsonIgnore]
        public DimensionColumnSpec Label
        {
            get { return VisualizationDataSpec.Label; }
            set { VisualizationDataSpec.Label = value; }
        }

        [JsonIgnore]
        public List<MeasureColumnSpec> Values { get { return VisualizationDataSpec.Value; } }

        [JsonProperty(Order = 7)]
        SingleGaugeVisualizationDataSpec VisualizationDataSpec { get; set; } = new SingleGaugeVisualizationDataSpec();
    }
}