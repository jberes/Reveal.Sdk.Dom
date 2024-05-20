using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class MicrosoftOneDriveDataSourceItem : DataSourceItem
    {
        internal MicrosoftOneDriveDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string Identifier { get; set; }
    }
}
