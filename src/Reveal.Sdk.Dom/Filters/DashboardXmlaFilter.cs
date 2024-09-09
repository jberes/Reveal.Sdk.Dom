using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Data;
using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Filters
{
    public sealed class DashboardXmlaFilter : DashboardDataFilterBase
    {
        [JsonProperty("DataSourceItem")]
        internal DataSourceItem DataSourceItem { get; set; }
        public string DimensionUniqueName { get; set; }
        public string HierarchyUniqueName { get; set; }
        public string LevelUniqueName { get; set; }
        public string MeasureUniqueName { get; set; }
        public int? Expiration { get; set; }

        internal DashboardXmlaFilter() : this(null) { }

        public DashboardXmlaFilter(DataSourceItem dataSourceItem)
        {
            SchemaTypeName = SchemaTypeNames.XmlaGlobalFilterType;
            DataSourceItem = dataSourceItem;
        }
    }
}
