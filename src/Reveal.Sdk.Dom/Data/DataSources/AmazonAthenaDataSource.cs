using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public class AmazonAthenaDataSource : DatabaseDataSource
    {
        public AmazonAthenaDataSource()
        {
            Provider = DataSourceProvider.AmazonAthena;
        }

        [JsonIgnore]
        public string DataCatalog
        {
            get => Properties.GetValue<string>("dataCatalog");
            set => Properties.SetItem("dataCatalog", value);
        }

        [JsonIgnore]
        public string OutputLocation
        {
            get => Properties.GetValue<string>("outputLocation");
            set => Properties.SetItem("outputLocation", value);
        }

        [JsonIgnore]
        public string Region
        {
            get => Properties.GetValue<string>("region");
            set => Properties.SetItem("region", value);
        }

        [JsonIgnore]
        public string Workgroup
        {
            get => Properties.GetValue<string>("workgroup");
            set => Properties.SetItem("workgroup", value);
        }
    }
}
