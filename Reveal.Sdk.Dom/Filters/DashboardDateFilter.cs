using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Primitives;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Filters
{
    public class DashboardDateFilter : DashboardFilter
    {
        public DateRange CustomDateRange { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DateRuleType RuleType { get; set; } = DateRuleType.LastYear;
        public bool IncludeToday { get; set; } = true;

        public DashboardDateFilter()
        {
            SchemaTypeName = SchemaTypeNames.DateGlobalFilterType;
            Title = "Date Filter";
        }
    }
}
