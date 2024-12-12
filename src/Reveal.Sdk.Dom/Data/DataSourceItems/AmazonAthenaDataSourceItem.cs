namespace Reveal.Sdk.Dom.Data
{
    public class AmazonAthenaDataSourceItem : TableDataSourceItem
    {
        public AmazonAthenaDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        public AmazonAthenaDataSourceItem(string title, AmazonAthenaDataSource dataSource) :
            base(title, dataSource)
        { }

        protected override DataSource CreateDataSourceInstance(DataSource dataSource)
        {
            return Create<AmazonAthenaDataSource>(dataSource);
        }
    }
}
