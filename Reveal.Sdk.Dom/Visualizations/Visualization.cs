using Reveal.Sdk.Dom.Core;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Serialization.Converters;
using Reveal.Sdk.Dom.Visualizations.DataSpecs;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class Visualization<TSettings, TVisualizationDataSpec> : Visualization
        where TSettings : VisualizationSettings, new()
        where TVisualizationDataSpec : VisualizationDataSpec, new()
    {
        [JsonInclude]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("VisualizationSettings")]
        public TSettings Settings { get; internal set; }

        //todo: think of a better name
        [JsonInclude]
        [JsonPropertyOrder(7)]
        [JsonConverter(typeof(VisualizationDataSpecConverter))]
        public TVisualizationDataSpec VisualizationDataSpec { get; internal set; }

        public Visualization() : this(null) { }

        public Visualization(DataSourceItem dataSourceItem) : base(dataSourceItem)
        {
            Settings = new TSettings();
            VisualizationDataSpec = new TVisualizationDataSpec();
        }
    }

    [JsonConverter(typeof(VisualizationConverter))]
    public abstract class Visualization
    {
        [JsonPropertyOrder(0)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [JsonPropertyOrder(1)]
        public string Title { get; set; }
        [JsonPropertyOrder(2)]
        public bool IsTitleVisible { get; set; } = true;
        [JsonPropertyOrder(3)]
        public int ColumnSpan { get; set; }
        [JsonPropertyOrder(4)]
        public int RowSpan { get; set; }

        //todo: think of a better name - maybe DataSchema since it represents the schema or structure of the data, or DataDefinition
        [JsonInclude]
        [JsonPropertyOrder(6)]
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

        public Visualization() : this(null) { }

        public Visualization(DataSourceItem dataSourceItem)
        {
            DataSpec = new TabularDataSpec();
            DataSpec.DataSourceItem = dataSourceItem;
            //DataSpec.Fields = dataSourceItem?.Fields;
            DataSpec.Fields = dataSourceItem?.Fields.Clone();
        }
    }
}