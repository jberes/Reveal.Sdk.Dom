using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public class HttpAnalysisServicesDataSource : MicrosoftAnalysisServicesDataSource
    {
        public HttpAnalysisServicesDataSource()
        {
            Properties.SetItem("Mode", "HTTP");
        }

        [JsonIgnore]
        public string Url
        {
            get => Properties.GetValue<string>("Url");
            set => Properties.SetItem("Url", value);
        }
    }
}
