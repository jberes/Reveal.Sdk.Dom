using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    internal class GoogleSheetsDataSourceItem : DataSourceItem
    {
        internal GoogleSheetsDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public bool FirstRowContainsLabels { get; set; }

        [JsonIgnore]
        public string NamedRange { get; set; }

        [JsonIgnore]
        public string PivotTable { get; set; }

        //todo: this is a nested object
        //[JsonIgnore]
        //public object Range { get; set; }

        [JsonIgnore]
        public string Sheet { get; set; }
    }
}
