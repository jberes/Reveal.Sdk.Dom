using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public class MicrosoftSqlServerDataSource : SchemaDataSource
    {
        public MicrosoftSqlServerDataSource()
        {
            Provider = DataSourceProvider.MicrosoftSqlServer;
        }

        [JsonIgnore]
        public bool Encrypt
        {
            get => Properties.GetValue<bool>("Encrypt");
            set => Properties.SetItem("Encrypt", value);
        }
    }
}
