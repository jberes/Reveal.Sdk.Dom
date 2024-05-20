using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class DropboxDataSourceItem : DataSourceItem
    {
        internal DropboxDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string Path { get; set; }
    }
}
