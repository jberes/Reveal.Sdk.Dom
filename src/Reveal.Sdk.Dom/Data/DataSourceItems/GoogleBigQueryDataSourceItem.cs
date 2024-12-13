using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public class GoogleBigQueryDataSourceItem : DataSourceItem
    {
        public GoogleBigQueryDataSourceItem(string title) :
            base(title, new GoogleBigQueryDataSource())
        { }

        public GoogleBigQueryDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        public GoogleBigQueryDataSourceItem(string title, GoogleBigQueryDataSource dataSource) : 
            base(title, dataSource) 
        { }

        [JsonIgnore]
        public string DataSetId
        {
            get => Properties.GetValue<string>("datasetId");
            set => Properties.SetItem("datasetId", value);
        }

        [JsonIgnore]
        public string ProjectId
        {
            get => Properties.GetValue<string>("ProjectId");
            set => Properties.SetItem("ProjectId", value);
        }

        [JsonIgnore]
        public string Table
        {
            get => Properties.GetValue<string>("tableId");
            set => Properties.SetItem("tableId", value);
        }

        protected override DataSource CreateDataSourceInstance(DataSource dataSource)
        {
            return Create<GoogleBigQueryDataSource>(dataSource);
        }
    }
}
