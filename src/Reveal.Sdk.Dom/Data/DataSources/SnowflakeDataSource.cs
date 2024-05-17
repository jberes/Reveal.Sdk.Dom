using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class SnowflakeDataSource : ProcessDataDatabaseSource
    {
        public SnowflakeDataSource()
        {
            Provider = DataSourceProvider.Snowflake;
        }

        [JsonIgnore]
        public string Account { get; set; }

        [JsonIgnore]
        public string Role { get; set; }

        [JsonIgnore]
        public string Warehouse { get; set; }
    }
}
