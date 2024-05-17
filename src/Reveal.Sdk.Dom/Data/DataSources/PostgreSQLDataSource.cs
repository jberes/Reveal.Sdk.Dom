namespace Reveal.Sdk.Dom.Data
{
    internal class PostgreSQLDataSource : SchemaDatabaseSource
    {
        public PostgreSQLDataSource()
        {
            Provider = DataSourceProvider.PostgreSQL;
        }
    }
}
