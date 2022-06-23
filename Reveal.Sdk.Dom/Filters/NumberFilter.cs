using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Filters
{
    public class NumberFilter : Filter
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public NumberRuleType RuleType { get; set; } = NumberRuleType.None;
		public double? Value { get; set; }

        public NumberFilter()
        {
			SchemaTypeName = SchemaTypeNames.NumberFilterType;
		}
    }
}
