using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core;
using Reveal.Sdk.Dom.Core.Serialization.Converters;

namespace Reveal.Sdk.Dom.Filters
{
    [JsonConverter(typeof(XmlaFilterRuleConverter))]
    public abstract class XmlaFilterRule : SchemaType
    {

    }
}
