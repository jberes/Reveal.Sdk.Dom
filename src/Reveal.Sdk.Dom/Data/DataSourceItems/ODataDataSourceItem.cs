using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class ODataDataSourceItem : DataSourceItem
    {
        internal ODataDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string EntityType { get; set; }

        [JsonIgnore]
        public string FunctionQName { get; set; }

        [JsonIgnore]
        public string Url { get; set; }
    }
}
