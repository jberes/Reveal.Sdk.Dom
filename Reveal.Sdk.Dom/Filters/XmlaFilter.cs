using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Filters
{
    public class XmlaFilter
    {
        public Filter Filter { get; set; }
        public string UniqueName { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DataType DataType { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public XmlaElementType ElementType { get; set; }
        public bool IsDynamic { get; set; }

        public XmlaFilter()
        {
            DataType = DataType.String;
            ElementType = XmlaElementType.Dimension;
        }
    }
}
