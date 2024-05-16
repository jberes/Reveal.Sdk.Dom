namespace Reveal.Sdk.Dom.Data
{
    public interface IDataSourceItemFactory
    {
        DataSourceItem Create(DataSourceType type, string id, string title);

        DataSourceItem Create(DataSourceType type, string id, string title, string subtitle);

        DataSourceItem Create(DataSourceType type, string id, string title, DataSource dataSource);

        DataSourceItem Create(DataSourceType type, string id, string title, string subtitle, DataSource dataSource);
    }
}
