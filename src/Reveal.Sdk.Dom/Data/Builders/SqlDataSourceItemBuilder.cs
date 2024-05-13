using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public class SqlDataSourceItemBuilder : DataSourceItemBuilder, ISqlDataSourceItemBuilder
    {
        //bug: if the database is not provided, the DSI Title will not be shown in the UI
        
        //todo: support more sql based connectors
        public SqlDataSourceItemBuilder(DataSource dataSource, string title) : 
            base(dataSource, DataSourceProvider.MicrosoftSqlServer, title)
        {
            Schema("dbo");
            DataSource.Properties.SetItem("ServerAggregationDefault", true);
            DataSource.Properties.SetItem("ServerAggregationReadOnly", false);
            DataSourceItem.Properties.SetItem("ServerAggregation", true);
        }

        public ISqlDataSourceItemBuilder Database(string database)
        {
            DataSource.Properties.SetItem("Database", database);
            DataSourceItem.Properties.SetItem("Database", database);
            return this;
        }

        public ISqlDataSourceItemBuilder Host(string host)
        {
            DataSource.Properties.SetItem("Host", host);
            return this;
        }

        public ISqlDataSourceItemBuilder Schema(string schema)
        {
            DataSourceItem.Properties.SetItem("Schema", schema);
            return this;
        }

        public ISqlDataSourceItemBuilder Table(string table)
        {
            DataSourceItem.Properties.SetItem("Table", table);
            return this;
        }
    }
}
