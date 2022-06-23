using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Primitives;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Filters
{
    public class XmlaDateFilter : Filter
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DateRuleType RuleType { get; set; } = DateRuleType.AllTime;
        public DateRange CustomDateRange { get; set; }
        public bool IncludeToday { get; set; } = true;

        public XmlaDateFilter()
        {
            SchemaTypeName = SchemaTypeNames.XmlaDateFilterType;
        }
    }
}
