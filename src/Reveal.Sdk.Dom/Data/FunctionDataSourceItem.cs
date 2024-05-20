using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    public abstract class FunctionDataSourceItem : SchemaDataSourceItem
    {
        public FunctionDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string FunctionName { get; set; }

        [JsonIgnore]
        public string FunctionParameters { get; set; }
    }
}
