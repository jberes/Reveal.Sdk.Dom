using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    internal class AmazonAthenaDataSource : DatabaseDataSource
    {
        public AmazonAthenaDataSource()
        {
            Provider = DataSourceProvider.AmazonAthena;
        }

        [JsonIgnore]
        public string DataCatalog
        {
            get => Properties.GetValue<string>("DataCatalog");
            set => Properties.SetItem("DataCatalog", value);
        }

        [JsonIgnore]
        public string OutputLocation
        {
            get => Properties.GetValue<string>("OutputLocation");
            set => Properties.SetItem("OutputLocation", value);
        }

        [JsonIgnore]
        public string Region
        {
            get => Properties.GetValue<string>("Region");
            set => Properties.SetItem("Region", value);
        }

        [JsonIgnore]
        public string Workgroup
        {
            get => Properties.GetValue<string>("Workgroup");
            set => Properties.SetItem("Workgroup", value);
        }
    }
}
