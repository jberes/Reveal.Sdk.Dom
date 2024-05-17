using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class ODataDataSource : WebServiceDataSource
    {
        public ODataDataSource()
        {
            Provider = DataSourceProvider.OData;
        }

        [JsonIgnore]
        public bool UsePreemptiveAuthentication { get; set; }
    }
}
