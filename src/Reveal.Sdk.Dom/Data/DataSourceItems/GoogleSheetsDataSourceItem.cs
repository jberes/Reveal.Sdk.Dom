using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    internal class GoogleSheetsDataSourceItem : DataSourceItem
    {
        public GoogleSheetsDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public bool FirstRowContainsLabels
        {
            get => Properties.GetValue<bool>("FirstRowContainsLabels");
            set => Properties.SetItem("FirstRowContainsLabels", value);
        }

        [JsonIgnore]
        public string NamedRange
        {
            get => Properties.GetValue<string>("NamedRange");
            set => Properties.SetItem("NamedRange", value);
        }

        [JsonIgnore]
        public string PivotTable
        {
            get => Properties.GetValue<string>("PivotTable");
            set => Properties.SetItem("PivotTable", value);
        }

        //todo: this is a nested object
        //[JsonIgnore]
        //public object Range { get; set; }

        [JsonIgnore]
        public string Sheet
        {
            get => Properties.GetValue<string>("Sheet");
            set => Properties.SetItem("Sheet", value);
        }
    }
}
