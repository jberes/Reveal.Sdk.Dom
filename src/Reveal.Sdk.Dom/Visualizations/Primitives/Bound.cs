using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class Bound
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public BoundValueType ValueType { get; set; } = BoundValueType.NumberValue;
        public double? Value { get; set; }
    }
}
