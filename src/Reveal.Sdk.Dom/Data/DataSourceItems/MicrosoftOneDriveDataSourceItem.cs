using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    internal class MicrosoftOneDriveDataSourceItem : DataSourceItem
    {
        public MicrosoftOneDriveDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string Identifier
        {
            get => Properties.GetValue<string>("Identifier");
            set => Properties.SetItem("Identifier", value);
        }
    }
}
