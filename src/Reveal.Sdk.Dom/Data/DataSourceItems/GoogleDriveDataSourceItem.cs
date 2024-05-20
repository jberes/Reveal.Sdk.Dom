using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class GoogleDriveDataSourceItem : DataSourceItem
    {
        internal GoogleDriveDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string Identitifer { get; set; }
    }
}
