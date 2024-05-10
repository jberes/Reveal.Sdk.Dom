namespace Reveal.Sdk.Dom.Data
{
    public class DataSourceResourceItemBuilder : DataSourceBuilder
    {
        protected DataSource ResourceItemDataSource = new DataSource(); //resource item data source
        protected DataSourceItem ResourceItem = new DataSourceItem(); //resource item that points to the data source

        public DataSourceResourceItemBuilder(DataSourceProvider dataSourceProvider, DataSourceProvider resourceItemDataSourceProvider, string title, string subtitle) :
            this(new DataSource(), dataSourceProvider, resourceItemDataSourceProvider, title, subtitle)
        { }

        public DataSourceResourceItemBuilder(DataSource dataSource, DataSourceProvider dataSourceProvider, DataSourceProvider resourceItemDataSourceProvider, string title, string subtitle) : 
            base(dataSource, dataSourceProvider, title, subtitle)
        {
            ResourceItemDataSource.Provider = resourceItemDataSourceProvider;
            ResourceItem.DataSource = ResourceItemDataSource;
            ResourceItem.DataSourceId = ResourceItemDataSource.Id;

            DataSourceItem.ResourceItemDataSource = ResourceItemDataSource;
            DataSourceItem.ResourceItem = ResourceItem;
        }
    }
}
