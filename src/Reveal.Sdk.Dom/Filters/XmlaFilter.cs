using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Filters
{
    public class XmlaFilter
    {
        public IFilter Filter { get; set; }
        public string UniqueName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public DataType DataType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public XmlaElementType ElementType { get; set; }
        public bool IsDynamic { get; set; }

        public XmlaFilter()
        {
            DataType = DataType.String;
            ElementType = XmlaElementType.Dimension;
        }
    }
}
