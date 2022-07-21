using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Filters
{
    public class TimeFilterType : FilterBase
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public TimeRuleType RuleType { get; set; } = TimeRuleType.AllTime;
        public DateRange CustomTimeRange { get; set; }

        public TimeFilterType()
        {
            SchemaTypeName = SchemaTypeNames.TimeFilterType;
        }
    }
}
