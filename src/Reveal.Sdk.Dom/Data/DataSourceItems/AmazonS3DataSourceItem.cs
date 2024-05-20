using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class AmazonS3DataSourceItem : DataSourceItem
    {
        internal AmazonS3DataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string Path { get; set; }
    }
}
