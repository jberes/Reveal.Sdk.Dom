using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Core.Serialization.Converters;

namespace Reveal.Sdk.Dom.Filters
{
    public abstract class Binding<TSource, TTarget> : Binding
        where TSource : BindingSource, new()
        where TTarget : BindingTarget, new()
    {
        [JsonConverter(typeof(BindingSourceConverter))]
        public TSource Source { get; set; }

        [JsonConverter(typeof(BindingTargetConverter))]
        public TTarget Target { get; set; }
    }

    [JsonConverter(typeof(BindingConverter))]
    public abstract class Binding
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public BindingOperatorType Operator { get; set; } = BindingOperatorType.Equals;
    }
}
