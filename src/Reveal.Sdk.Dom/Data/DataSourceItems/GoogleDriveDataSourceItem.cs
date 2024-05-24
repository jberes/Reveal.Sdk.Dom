using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    internal class GoogleDriveDataSourceItem : DataSourceItem
    {
        public GoogleDriveDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string Identitifer
        {
            get => Properties.GetValue<string>("Identitifer");
            set => Properties.SetItem("Identitifer", value);
        }
    }
}
