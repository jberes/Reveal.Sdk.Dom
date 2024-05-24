using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    internal class GoogleBigQueryDataSourceItem : TableDataSourceItem
    {
        internal GoogleBigQueryDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string DataSetId
        {
            get => Properties.GetValue<string>("DataSetId");
            set => Properties.SetItem("DataSetId", value);
        }

        [JsonIgnore]
        public string ProjectId
        {
            get => Properties.GetValue<string>("ProjectId");
            set => Properties.SetItem("ProjectId", value);
        }
    }
}
