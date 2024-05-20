namespace Reveal.Sdk.Dom.Data
{
    internal class PostgreSQLDataSource : SchemaDataSource
    {
        public PostgreSQLDataSource()
        {
            Provider = DataSourceProvider.PostgreSQL;
        }
    }
}
