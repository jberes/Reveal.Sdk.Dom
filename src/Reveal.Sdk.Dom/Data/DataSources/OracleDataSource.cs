using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class OracleDataSource : HostDataSource
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
