using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    internal class DropboxDataSourceItem : DataSourceItem
    {
        internal DropboxDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string Path
        {
            get => Properties.GetValue<string>("Path");
            set => Properties.SetItem("Path", value);
        }
    }
}
