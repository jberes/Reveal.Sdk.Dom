using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class SingleGaugeVisualizationBase<TSettings> : Visualization<TSettings>, ILabel, IValues, IBands
        where TSettings : GaugeVisualizationSettings, new()
    {
        protected SingleGaugeVisualizationBase(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonIgnore]
        public DimensionColumnSpec Label
        {
            get { return VisualizationDataSpec.Label; }
            set { VisualizationDataSpec.Label = value; }
        }

        [JsonIgnore]
        public List<MeasureColumnSpec> Values { get { return VisualizationDataSpec.Value; } }

        [JsonIgnore]
        public List<GaugeBand> Bands { get { return Settings.GaugeBands; } }

        [JsonProperty(Order = 7)]
        SingleGaugeVisualizationDataSpec VisualizationDataSpec { get; set; } = new SingleGaugeVisualizationDataSpec();
    }
}