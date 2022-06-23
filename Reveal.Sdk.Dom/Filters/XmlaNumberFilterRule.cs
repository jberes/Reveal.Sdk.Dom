using Reveal.Sdk.Dom.Core.Constants;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Filters
{
    public class XmlaNumberFilterRule : XmlaFilterRule
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public NumberRuleType RuleType { get; set; } = NumberRuleType.None;
        public double? Value { get; set; }

        public XmlaNumberFilterRule()
        {
            SchemaTypeName = SchemaTypeNames.XmlaNumberFilterRuleType;
        }
    }
}
