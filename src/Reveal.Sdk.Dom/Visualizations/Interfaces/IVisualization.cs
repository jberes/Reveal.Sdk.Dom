using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Serialization.Converters;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface IVisualization<out TSettings, out TDataSpec> : IVisualization
        where TSettings : VisualizationSettings
        where TDataSpec : DataDefinitionBase
    {
        TDataSpec DataDefinition { get; }
        List<Binding> FilterBindings { get; }
        TSettings Settings { get; }
    }

    [JsonConverter(typeof(VisualizationConverter))]
    public interface IVisualization
    {
        string Id { get; set; }
        string Title { get; set; }
        bool IsTitleVisible { get; set; }
        int ColumnSpan { get; set; }
        int RowSpan { get; set; }
    }
}