using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class MongoDbDataSourceItem : DataSourceItem
    {
        public MongoDbDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string Collection { get; set; }

        [JsonIgnore]
        public bool ProcessDataOnServer { get; set; }
    }
}
