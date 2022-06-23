using Reveal.Sdk.Dom.Core.Constants;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Filters
{
    public class XmlaStringFilterRule : XmlaFilterRule
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StringRuleType RuleType { get; set; } = StringRuleType.None;
        public string Value { get; set; }

        public XmlaStringFilterRule()
        {
            SchemaTypeName = SchemaTypeNames.XmlaStringFilterRuleType;
        }
    }
}
