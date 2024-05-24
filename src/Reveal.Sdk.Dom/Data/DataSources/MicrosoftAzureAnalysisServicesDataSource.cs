using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    internal class MicrosoftAzureAnalysisServicesDataSource : MicrosoftAnalysisServicesDataSource
    {
        public MicrosoftAzureAnalysisServicesDataSource()
        {
            Provider = DataSourceProvider.MicrosoftAzureAnalysisServices;
        }

        [JsonIgnore]
        public string ServerUrl
        {
            get => Properties.GetValue<string>("ServerUrl");
            set => Properties.SetItem("ServerUrl", value);
        }
    }
}
