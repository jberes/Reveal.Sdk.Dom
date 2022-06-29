using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Utilities;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.DataSpecs;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    //todo: maybe should rename to TabularVisualization
    public abstract class Visualization<T> : Visualization<T, TabularDataSpec>, IFilter
        where T : VisualizationSettings, new()
    {
        protected Visualization(DataSourceItem dataSourceItem) : this(string.Empty, dataSourceItem) { }
        protected Visualization(string title, DataSourceItem dataSourceItem) : base(title)
        {
            DataSpec = new TabularDataSpec
            {
                DataSourceItem = dataSourceItem,
                Fields = dataSourceItem?.Fields.Clone()
            };
        }

        [JsonIgnore]
        public List<VisualizationFilter> Filters
        {
            get { return DataSpec.QuickFilters; }
        }
    }

    public abstract class Visualization<TSettings, TDataSpec> : Visualization, IDataSpec<TDataSpec>, IBindDashboardFilters
        where TSettings : VisualizationSettings, new()
        where TDataSpec : DataSpec
    {
        protected Visualization(string title) : base(title) { }

        ////todo: implement
        //[JsonProperty(Order = 10)]
        //internal ActionsModel ActionsModel { get; set; }

        [JsonProperty("VisualizationSettings", Order = 5)]
        public TSettings Settings { get; internal set; } = new TSettings();

        //todo: think of a better name - maybe DataSchema since it represents the schema or structure of the data, or DataDefinition
        //does this even need to be expose? Can the properties be wrapped?
        [JsonProperty(Order = 6)]
        public TDataSpec DataSpec { get; internal set; }

        [JsonIgnore]
        public List<Binding> FilterBindings
        {
            get { return DataSpec.Bindings.Bindings; }
        }
    }

    public abstract class Visualization : IVisualization
    {
        protected Visualization(string title)
        {
            Title = title;
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
    }
}