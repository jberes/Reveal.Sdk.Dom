namespace Reveal.Sdk.Dom.Data
{
    public abstract class DataSourceResourceItemBuilder : DataSourceItemBuilder
    {
        protected DataSource ResourceItemDataSource { get; private set; } //resource item data source
        protected DataSourceItem ResourceItem { get; private set; } //resource item that points to the data source

        public DataSourceResourceItemBuilder(DataSourceProvider dataSourceProvider, DataSourceProvider resourceItemDataSourceProvider, string title) :
            this(new DataSource(), dataSourceProvider, resourceItemDataSourceProvider, title)
        { }

        public DataSourceResourceItemBuilder(DataSource dataSource, DataSourceProvider dataSourceProvider, DataSourceProvider resourceItemDataSourceProvider, string title) : 
            base(dataSource, dataSourceProvider, title)
        {
            InitializeResourceItem(resourceItemDataSourceProvider, title);
        }

        private void InitializeResourceItem(DataSourceProvider resourceItemDataSourceProvider, string title)
        {
            ResourceItemDataSource = new DataSource { Provider = resourceItemDataSourceProvider };
            ResourceItem = new DataSourceItem
            {
                DataSource = ResourceItemDataSource,
                DataSourceId = ResourceItemDataSource.Id,
                Title = title
            };

            DataSourceItem.ResourceItemDataSource = ResourceItemDataSource;
            DataSourceItem.ResourceItem = ResourceItem;
        }
    }
}
