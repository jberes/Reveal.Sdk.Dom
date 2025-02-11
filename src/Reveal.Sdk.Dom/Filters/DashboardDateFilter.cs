using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Filters
{
    public sealed class DashboardDateFilter : DashboardFilter
    {
        public DateRange CustomDateRange { get; set; }

        public bool IncludeToday { get; set; } = true;

        [JsonConverter(typeof(StringEnumConverter))]
        public DateRuleType RuleType { get; set; } = DateRuleType.LastYear;

        public DashboardDateFilter() : this("Date Filter") { }

        public DashboardDateFilter(string title)
        {
            SchemaTypeName = SchemaTypeNames.DateGlobalFilterType;
            Title = title;
            Id = "_date";
        }
    }
}
