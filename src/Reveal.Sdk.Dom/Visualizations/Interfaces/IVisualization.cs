using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Serialization.Converters;

namespace Reveal.Sdk.Dom.Visualizations
{
    [JsonConverter(typeof(VisualizationConverter))]
    public interface IVisualization
    {
        string Id { get; set; }
        ChartType ChartType { get; }
        string Title { get; set; }
        bool IsTitleVisible { get; set; }
        int ColumnSpan { get; set; }
        int RowSpan { get; set; }
        IDataDefinition DataDefinition { get; }
    }
}