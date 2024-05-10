using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public class SqlBuilder : DataSourceBuilder, ISqlBuilder
    {
        //bug: if the database is not provided, the DSI Title will not be shown in the UI

        public SqlBuilder(DataSource dataSource, string title, string id) : 
            base(dataSource, DataSourceProvider.MicrosoftSqlServer, title, id)
        {
            Schema("dbo");
            DataSource.Properties.SetItem("ServerAggregationDefault", true);
            DataSource.Properties.SetItem("ServerAggregationReadOnly", false);
            DataSourceItem.Properties.SetItem("ServerAggregation", true);
        }

        public ISqlBuilder Database(string database)
        {
            DataSource.Properties.SetItem("Database", database);
            DataSourceItem.Properties.SetItem("Database", database);
            return this;
        }

        public ISqlBuilder Host(string host)
        {
            DataSource.Properties.SetItem("Host", host);
            return this;
        }

        public ISqlBuilder Schema(string schema)
        {
            DataSourceItem.Properties.SetItem("Schema", schema);
            return this;
        }

        public ISqlBuilder Table(string table)
        {
            DataSourceItem.Properties.SetItem("Table", table);
            return this;
        }
    }
}
