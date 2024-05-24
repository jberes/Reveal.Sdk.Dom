using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public class MicrosoftAnalysisServicesDataSource : DataSource
    {
        public MicrosoftAnalysisServicesDataSource()
        {
            Provider = DataSourceProvider.MicrosoftAnalysisServices;
        }

        [JsonIgnore]
        public string Catalog
        {
            get => Properties.GetValue<string>("Catalog");
            set => Properties.SetItem("Catalog", value);
        }

        [JsonIgnore]
        public string Host
        {
            get => Properties.GetValue<string>("Host");
            set => Properties.SetItem("Host", value);
        }

        [JsonIgnore]
        public int Port
        {
            get => Properties.GetValue<int>("Port");
            set => Properties.SetItem("Port", value);
        }
    }
}
