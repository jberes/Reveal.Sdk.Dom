using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Primitives;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Filters
{
    public class DateTimeFilter :Filter
    {
        public int DateFiscalYearStartMonth { get; set; }
        public bool DisplayInLocalTimeZone { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DateRuleType RuleType { get; set; } = DateRuleType.AllTime;
        public DateRange CustomDateRange { get; set; }
        public bool IncludeToday { get; set; } = true;

        public DateTimeFilter()
        {
            SchemaTypeName = SchemaTypeNames.DateTimeFilterType;
        }
    }
}
