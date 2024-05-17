using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class MicrosoftAnalysisServicesDataSource : DataSource
    {
        public MicrosoftAnalysisServicesDataSource()
        {
            Provider = DataSourceProvider.MicrosoftAnalysisServices;
        }

        [JsonIgnore]
        public string Catalog { get; set; }

        [JsonIgnore]
        public string Host { get; set; }

        [JsonIgnore]
        public int Port { get; set; }
    }
}
