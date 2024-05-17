using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class MicrosoftAzureSqlServerDataSource : MicrosoftSqlServerDataSource
    {
        public MicrosoftAzureSqlServerDataSource()
        {
            Provider = DataSourceProvider.MicrosoftAzureSqlServer;
        }

        [JsonIgnore]
        public bool TrustServerCertificate { get; set; } //todo: implement
    }
}
