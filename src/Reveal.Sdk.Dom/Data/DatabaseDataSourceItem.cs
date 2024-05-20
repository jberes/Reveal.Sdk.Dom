using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public abstract class DatabaseDataSourceItem : TableDataSourceItem
    {
        public DatabaseDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string Database
        {
            get => Properties.GetValue<string>("Database");
            set => Properties.SetItem("Database", value);
        }
    }
}
