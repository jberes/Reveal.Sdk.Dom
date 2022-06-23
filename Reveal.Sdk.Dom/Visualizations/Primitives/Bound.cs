using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class Bound
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BoundValueType ValueType { get; set; }
        public double? Value { get; set; }
        public Bound()
        {
            ValueType = BoundValueType.NumberValue;
        }
    }
}
