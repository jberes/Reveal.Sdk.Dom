using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class LinearGaugeVisualizationBase<TSettings> : TabularVisualizationBase<TSettings>, ILabels, IValues
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

        [JsonProperty(Order = 7)]
        internal LinearGaugeVisualizationDataSpec VisualizationDataSpec { get; set; } = new LinearGaugeVisualizationDataSpec();
    }
}