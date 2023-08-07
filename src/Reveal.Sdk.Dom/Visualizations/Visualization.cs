using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class Visualization<TSettings, TDataDefinition> : Visualization, ISettingsProvider<TSettings>, IDataDefinitionProvider<TDataDefinition>, IFilterBindings
        where TSettings : VisualizationSettings, new()
        where TDataDefinition : DataDefinitionBase
    {
        protected Visualization(string title) : base(title) { }

        [JsonProperty("DataSpec", Order = 6)]
        public TDataDefinition DataDefinition { get; internal set; }

        [JsonIgnore]
        public List<Binding> FilterBindings
        {
            get { return DataDefinition.Bindings.Bindings; }
        }

        [JsonProperty("ActionsModel", Order = 10)]
        public VisualizationLinker Linker { get; set; }

        [JsonProperty("VisualizationSettings", Order = 5)]
        public TSettings Settings { get; internal set; } = new TSettings();
    }

    public abstract class Visualization : IVisualization, IParentDocument
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

        [JsonIgnore]
        RdashDocument IParentDocument.Document { get; set; }
    }
}