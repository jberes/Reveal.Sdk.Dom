using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Core.Utilities;
using Reveal.Sdk.Dom.Visualizations;

namespace Reveal.Sdk.Dom.Filters
{
    public sealed class DashboardDataFilter : DashboardDataFilterBase
    {
        //todo: rename to DataDefinition
        public TabularDataDefinition DataSpec { get; internal set; } = new TabularDataDefinition();
        public string SelectedFieldName { get; set; }

        internal DashboardDataFilter() : this(null) { }

        public DashboardDataFilter(DataSourceItem dataSourceItem)
        {
            SchemaTypeName = SchemaTypeNames.TabularGlobalFilterType;
            DataSpec.DataSourceItem = dataSourceItem;
            DataSpec.Fields = dataSourceItem?.Fields.Clone();
        }
    }
}
