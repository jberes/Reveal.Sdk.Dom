using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class AmazonS3DataSource : DataSource
    {
        public AmazonS3DataSource()
        {
            Provider = DataSourceProvider.AmazonS3;
        }

        [JsonIgnore]
        public string AccountId { get; set; }

        [JsonIgnore]
        public string Region { get; set; }
    }
}
