using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class Bound
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public BoundValueType ValueType { get; set; }
        public double? Value { get; set; }
        public Bound()
        {
            ValueType = BoundValueType.NumberValue;
        }
    }
}
