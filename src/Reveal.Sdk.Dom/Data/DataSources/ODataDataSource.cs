using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    internal class ODataDataSource : WebServiceDataSource
    {
        public ODataDataSource()
        {
            Provider = DataSourceProvider.OData;
        }

        [JsonIgnore]
        public bool UsePreemptiveAuthentication
        {
            get => Properties.GetValue<bool>("UsePreemptiveAuthentication");
            set => Properties.SetItem("UsePreemptiveAuthentication", value);
        }
    }
}
