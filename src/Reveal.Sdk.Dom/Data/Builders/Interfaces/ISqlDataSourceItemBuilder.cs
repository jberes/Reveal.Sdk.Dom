namespace Reveal.Sdk.Dom.Data
{
    public interface ISqlDataSourceItemBuilder : IDataSourceItemBuilder
    {
        ISqlDataSourceItemBuilder Database(string database);
        ISqlDataSourceItemBuilder Host(string host);
        ISqlDataSourceItemBuilder Schema(string schema);
        ISqlDataSourceItemBuilder Table(string table);
    }
}
