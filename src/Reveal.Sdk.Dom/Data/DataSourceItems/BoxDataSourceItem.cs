using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class BoxDataSourceItem : DataSourceItem
    {
        internal BoxDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string Identifier { get; set; }
    }
}
