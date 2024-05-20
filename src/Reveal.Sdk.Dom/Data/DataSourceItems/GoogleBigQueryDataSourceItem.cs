using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class GoogleBigQueryDataSourceItem : TableDataSourceItem
    {
        internal GoogleBigQueryDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string DataSetId { get; set; }

        [JsonIgnore]
        public string ProjectId { get; set; }
    }
}
