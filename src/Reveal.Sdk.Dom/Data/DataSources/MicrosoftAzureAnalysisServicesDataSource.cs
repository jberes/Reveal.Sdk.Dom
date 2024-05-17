using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class MicrosoftAzureAnalysisServicesDataSource : MicrosoftAnalysisServicesDataSource
    {
        public MicrosoftAzureAnalysisServicesDataSource()
        {
            Provider = DataSourceProvider.MicrosoftAzureAnalysisServices;
        }

        [JsonIgnore]
        public string ServerUrl { get; set; }
    }
}
