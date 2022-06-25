using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Serialization.Converters;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class LinearGaugeVisualizationBase<TSettings> : Visualization<TSettings>
        where TSettings : VisualizationSettings, new()
    {
        protected LinearGaugeVisualizationBase(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        //todo: are these labels, rows, or categories
        [JsonIgnore]
        public List<DimensionColumnSpec> Labels 
        { 
            get { return VisualizationDataSpec.Rows; } 
        }

        //todo: this doesn't seem to be used, why is it on the LinearGaugeVisualizationDataSpec?
        //maybe another visualization uses it?
        //[JsonIgnore]
        //public List<MeasureColumnSpec> Target
        //{
        //    get { return GetVisualizationDataSpec().Target; }
        //}

        [JsonIgnore]
        public List<MeasureColumnSpec> Values
        {
            get { return VisualizationDataSpec.Value; }
        }

        [JsonProperty(Order = 7)]
        [JsonConverter(typeof(VisualizationDataSpecConverter))]
        LinearGaugeVisualizationDataSpec VisualizationDataSpec { get; set; } = new LinearGaugeVisualizationDataSpec();
    }
}