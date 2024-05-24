using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    internal class ODataDataSourceItem : DataSourceItem
    {
        internal ODataDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string EntityType
        {
            get => Properties.GetValue<string>("EntityType");
            set => Properties.SetItem("EntityType", value);
        }

        [JsonIgnore]
        public string FunctionQName
        {
            get => Properties.GetValue<string>("FunctionQName");
            set => Properties.SetItem("FunctionQName", value);
        }

        [JsonIgnore]
        public string Url
        {
            get => Properties.GetValue<string>("Url");
            set => Properties.SetItem("Url", value);
        }
    }
}
