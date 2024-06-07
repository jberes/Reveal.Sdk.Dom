using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Filters
{
    public sealed class XmlaNumberFilterRule : XmlaFilterRule
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public NumberRuleType RuleType { get; set; } = NumberRuleType.None;
        public double? Value { get; set; }

        public XmlaNumberFilterRule()
        {
            SchemaTypeName = SchemaTypeNames.XmlaNumberFilterRuleType;
        }
    }
}
