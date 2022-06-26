using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Serialization.Converters;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.DataSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    [JsonConverter(typeof(VisualizationConverter))]
    public interface IVisualization
    {
        string Id { get; set; }
        string Title { get; set; }
        bool IsTitleVisible { get; set; }
        int ColumnSpan { get; set; }
        int RowSpan { get; set; }
        List<Binding> FilterBindings { get; }
        List<VisualizationFilter> Filters { get; }
        TabularDataSpec DataSpec { get; }
    }
}