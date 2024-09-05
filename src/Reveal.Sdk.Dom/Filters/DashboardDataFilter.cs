using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Core.Utilities;
using Reveal.Sdk.Dom.Visualizations;
using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Filters
{
    public sealed class DashboardDataFilter : DashboardDataFilterBase
    {
        [JsonProperty("DataSpec")]
        public TabularDataDefinition DataDefinition { get; internal set; } = new TabularDataDefinition();

        public string SelectedFieldName { get; set; }

        internal DashboardDataFilter() : this(null) { }

        public DashboardDataFilter(DataSourceItem dataSourceItem)
        {
            SchemaTypeName = SchemaTypeNames.TabularGlobalFilterType;
            DataDefinition.DataSourceItem = dataSourceItem;
            DataDefinition.Fields = dataSourceItem?.Fields.Clone();
        }

        public void SelectValues(params object[] values)
        {
            SelectedItems.Clear();
            foreach (var value in values)
            {
                SelectedItems.Add(new FilterItem(SelectedFieldName, value));
            }
        }
    }
}
