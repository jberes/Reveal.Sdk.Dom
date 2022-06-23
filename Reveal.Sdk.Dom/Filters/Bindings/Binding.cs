using Reveal.Sdk.Dom.Serialization.Converters;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Filters
{
    public class Binding<TSource, TTarget> : Binding
        where TSource : BindingSource, new()
        where TTarget : BindingTarget, new()
    {
        [JsonConverter(typeof(BindingSourceConverter))]
        public TSource Source { get; set; }

        [JsonConverter(typeof(BindingTargetConverter))]
        public TTarget Target { get; set; }
    }

    [JsonConverter(typeof(BindingConverter))]
    public class Binding
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BindingOperatorType Operator { get; set; } = BindingOperatorType.Equals;
    }
}
