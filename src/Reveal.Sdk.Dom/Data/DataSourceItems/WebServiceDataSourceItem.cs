using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class WebServiceDataSourceItem : DataSourceItem
    {
        internal WebServiceDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string Url { get; set; }
    }
}
