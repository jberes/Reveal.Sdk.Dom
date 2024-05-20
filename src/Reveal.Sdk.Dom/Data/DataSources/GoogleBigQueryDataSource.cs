using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class GoogleBigQueryDataSource : DatabaseDataSource
    {
        public GoogleBigQueryDataSource()
        {
            Provider = DataSourceProvider.GoogleBigQuery;
        }

        [JsonIgnore]
        public string ProjectId { get; set; }
    }
}
