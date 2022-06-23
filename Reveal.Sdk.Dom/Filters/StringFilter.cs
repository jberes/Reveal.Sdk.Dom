using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Filters
{
    public class StringFilter : Filter
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public StringRuleType RuleType { get; set; } = StringRuleType.None;
        public string Value { get; set; }

        public StringFilter()
        {
            SchemaTypeName = SchemaTypeNames.StringFilterType;
        }
    }
}
