using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class LinearGaugeVisualizationBase<TSettings> : Visualization<TSettings>, ILabels, IValues, IBands
        where TSettings : GaugeVisualizationSettings, new()
    {
        protected LinearGaugeVisualizationBase(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonIgnore]
        public List<DimensionColumnSpec> Labels 
        { 
            get { return VisualizationDataSpec.Rows; } 
        }

        [JsonIgnore]
        public List<MeasureColumnSpec> Values
        {
            get { return VisualizationDataSpec.Value; }
        }

        [JsonIgnore]
        public List<GaugeBand> Bands { get { return Settings.GaugeBands; } }

        [JsonProperty(Order = 7)]
        LinearGaugeVisualizationDataSpec VisualizationDataSpec { get; set; } = new LinearGaugeVisualizationDataSpec();
    }
}