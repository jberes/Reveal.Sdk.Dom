using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    public class MicrosoftAnalysisServicesDataSourceItem : DataSourceItem
    {
        public  MicrosoftAnalysisServicesDataSourceItem(string title, MicrosoftAnalysisServicesDataSource dataSource) :
            base(title, dataSource)
        { }

        internal MicrosoftAnalysisServicesDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string Catalog { get; set; }

        [JsonIgnore]
        public string Cube { get; set; }

        protected override DataSource CreateDataSourceInstance(DataSource dataSource)
        {
            return Create<MicrosoftAnalysisServicesDataSource>(dataSource);
        }
    }
}
