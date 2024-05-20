using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class MicrosoftAnalysisServicesDataSourceItem : DataSourceItem
    {
        internal MicrosoftAnalysisServicesDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string Catalog { get; set; }

        [JsonIgnore]
        public string Cube { get; set; }
    }
}
