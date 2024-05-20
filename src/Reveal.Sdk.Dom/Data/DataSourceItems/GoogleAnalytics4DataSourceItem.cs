using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class GoogleAnalytics4DataSourceItem : DataSourceItem
    {
        internal GoogleAnalytics4DataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string AccountId { get; set; }

        [JsonIgnore]
        public string PropertyId { get; set; }
    }
}
