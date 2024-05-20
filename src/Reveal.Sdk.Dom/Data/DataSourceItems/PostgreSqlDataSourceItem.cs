using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    public class PostgreSqlDataSourceItem : FunctionDataSourceItem
    {
        public PostgreSqlDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public bool ProcessDataOnServer { get; set; }
    }
}
