using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Filters
{
    public sealed class XmlaDateFilter : FilterBase
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public DateRuleType RuleType { get; set; } = DateRuleType.AllTime;
        public DateRange CustomDateRange { get; set; }
        public bool IncludeToday { get; set; } = true;

        public XmlaDateFilter()
        {
            SchemaTypeName = SchemaTypeNames.XmlaDateFilterType;
        }
    }
}
