using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Primitives;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Filters
{
    public class TimeFilterType : Filter
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TimeRuleType RuleType { get; set; } = TimeRuleType.AllTime;
        public DateRange CustomTimeRange { get; set; }

        public TimeFilterType()
        {
            SchemaTypeName = SchemaTypeNames.TimeFilterType;
        }
    }
}
