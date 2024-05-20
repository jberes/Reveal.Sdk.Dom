using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public abstract class SchemaDataSourceItem : DatabaseDataSourceItem
    {
        public SchemaDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string Schema
        {
            get => Properties.GetValue<string>("Schema");
            set => Properties.SetItem("Schema", value);
        }

    }
}
