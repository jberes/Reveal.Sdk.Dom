using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Filters
{
    public sealed class TextFilter : FilterBase
    {
        public TextFilter()
        {
            SchemaTypeName = SchemaTypeNames.StringFilterType;
        }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public StringRuleType RuleType { get; set; } = StringRuleType.None;
        
        public string Value { get; set; }
    }
}
