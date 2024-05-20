using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class SnowflakeDataSourceItem : SchemaDataSourceItem
    {
        public SnowflakeDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public bool ProcessDataOnServer { get; set; }
    }
}
