namespace Reveal.Sdk.Dom.Data
{
    public interface ISqlBuilder : IDataSourceBuilder
    {
        ISqlBuilder Database(string database);
        ISqlBuilder Host(string host);
        ISqlBuilder Schema(string schema);
        ISqlBuilder Table(string table);
    }
}
