using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class OracleDataSource : HostDatabaseSource
    {
        public OracleDataSource()
        {
            Provider = DataSourceProvider.Oracle;
        }

        [JsonIgnore]
        public string Service { get; set; } //todo: should this be two separate objects?

        [JsonIgnore]
        public string SID { get; set; }
    }
}
