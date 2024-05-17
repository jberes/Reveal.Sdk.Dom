using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class WebServiceDataSource : DataSource
    {
        public WebServiceDataSource()
        {
            Provider = DataSourceProvider.WebService;
        }

        [JsonIgnore]
        public string URL { get; set; }

        [JsonIgnore]
        public bool UseAnonymousAuthentication { get; set; }
    }
}
