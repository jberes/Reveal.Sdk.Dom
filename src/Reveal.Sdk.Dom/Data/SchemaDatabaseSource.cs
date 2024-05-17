using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public class SchemaDatabaseSource : ProcessDataDatabaseSource
    {
        [JsonIgnore]
        public string Schema
        {
            get => Properties.GetValue<string>("Schema");
            set => Properties.SetItem("Schema", value);
        }
    }
}
