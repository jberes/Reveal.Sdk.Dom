using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public class SchemaDataSource : ProcessDataSource
    {
        [JsonIgnore]
        public string Schema
        {
            get => Properties.GetValue<string>("Schema");
            set => Properties.SetItem("Schema", value);
        }
    }
}
