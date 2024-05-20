using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class AmazonAthenaDataSource : DatabaseDataSource
    {
        public AmazonAthenaDataSource()
        {
            Provider = DataSourceProvider.AmazonAthena;
        }

        [JsonIgnore]
        public string DataCatalog { get; set; }

        [JsonIgnore]
        public string OutputLocation { get; set; }

        [JsonIgnore]
        public string Region { get; set; }

        [JsonIgnore]
        public string Workgroup { get; set; }
    }
}
