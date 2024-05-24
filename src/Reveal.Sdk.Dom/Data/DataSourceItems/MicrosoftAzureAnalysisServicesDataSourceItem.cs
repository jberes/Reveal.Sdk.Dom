namespace Reveal.Sdk.Dom.Data
{
    internal class MicrosoftAzureAnalysisServicesDataSourceItem : DataSourceItem
    {
        public MicrosoftAzureAnalysisServicesDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        {
            HasTabularData = false;
        }
    }
}
