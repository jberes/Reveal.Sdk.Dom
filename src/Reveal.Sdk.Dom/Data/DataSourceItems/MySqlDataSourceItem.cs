using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class MySqlDataSourceItem : ProcedureDataSourceItem
    {
        public MySqlDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public bool ProcessDataOnServer { get; set; }
    }
}
