using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public abstract class TableDataSourceItem : DataSourceItem
    {
        public TableDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string Table
        {
            get => Properties.GetValue<string>("Table");
            set => Properties.SetItem("Table", value);
        }
    }
}
