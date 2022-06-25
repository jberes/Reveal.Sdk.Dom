using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Serialization.Converters;
using Reveal.Sdk.Dom.Visualizations.DataSpecs;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    //todo: drop this
    //public abstract class Visualization<TSettings, TVisualizationDataSpec> : Visualization, IVisualizationDataSpec<TVisualizationDataSpec>
    //    where TSettings : VisualizationSettings, new()
    //    where TVisualizationDataSpec : VisualizationDataSpec, new()
    //{
    //    protected Visualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

    //    [JsonProperty("VisualizationSettings", Order = 5)]
    //    public TSettings Settings { get; internal set; } = new TSettings();


    //    TVisualizationDataSpec IVisualizationDataSpec<TVisualizationDataSpec>.VisualizationDataSpec { get { return VisualizationDataSpec; } }

    //    //todo: think of a better name
    //    [JsonProperty("VisualizationDataSpec", Order = 7)]
    //    [JsonConverter(typeof(VisualizationDataSpecConverter))]
    //    TVisualizationDataSpec VisualizationDataSpec { get; set; } = new TVisualizationDataSpec();

    //    protected TVisualizationDataSpec GetVisualizationDataSpec()
    //    {
    //        return (this as IVisualizationDataSpec<TVisualizationDataSpec>).VisualizationDataSpec;
    //    }
    //}

    public abstract class Visualization<TSettings> : Visualization
    where TSettings : VisualizationSettings, new()
    {
        protected Visualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        [JsonProperty("VisualizationSettings", Order = 5)]
        public TSettings Settings { get; internal set; } = new TSettings();
    }

    [JsonConverter(typeof(VisualizationConverter))]
    public abstract class Visualization
    {
        protected Visualization(DataSourceItem dataSourceItem)
        {
            DataSpec = new TabularDataSpec
            {
                DataSourceItem = dataSourceItem,
                Fields = dataSourceItem?.Fields.Clone()
            };
        }

        [JsonProperty(Order = 0)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [JsonProperty(Order = 1)]
        public string Title { get; set; }
        [JsonProperty(Order = 2)]
        public bool IsTitleVisible { get; set; } = true;
        [JsonProperty(Order = 3)]
        public int ColumnSpan { get; set; }
        [JsonProperty(Order = 4)]
        public int RowSpan { get; set; }

        //todo: think of a better name - maybe DataSchema since it represents the schema or structure of the data, or DataDefinition
        //does this even need to be expose? Can the properties be wrapped?
        [JsonProperty(Order = 6)]
        [JsonConverter(typeof(DataSpecConverter))]
        public TabularDataSpec DataSpec { get; internal set; }

        [JsonIgnore]
        public List<Binding> FilterBindings
        {
            get { return DataSpec.Bindings.Bindings; }
        }

        [JsonIgnore]
        public List<VisualizationFilter> Filters
        {
            get { return DataSpec.QuickFilters; }
        }
    }
}