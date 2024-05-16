using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public class MicrosoftSqlServerDataSourceItem : DataSourceItem
    {
        public MicrosoftSqlServerDataSourceItem(string title) :
            base(title, new DataSource())
        { }

        public MicrosoftSqlServerDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        public string Database
        {
            get => Properties.GetValue<string>("Database");
            set
            {
                Properties.SetItem("Database", value);
                DataSource.Properties.SetItem("Database", value);
            }
        }

        public string Host
        {
            get => DataSource.Properties.GetValue<string>("Host");
            set => DataSource.Properties.SetItem("Host", value);
        }

        public string Schema
        {
            get => Properties.GetValue<string>("Schema");
            set => Properties.SetItem("Schema", value);
        }

        public string Table
        {
            get => Properties.GetValue<string>("Table");
            set => Properties.SetItem("Table", value);
        }

        protected override void InitializeDataSource(DataSource dataSource, string title)
        {
            base.InitializeDataSource(dataSource, title);
            DataSource.Provider = DataSourceProvider.MicrosoftSqlServer;
            DataSource.Properties.SetItem("ServerAggregationDefault", true);
            DataSource.Properties.SetItem("ServerAggregationReadOnly", false);
        }

        override protected void InitializeDataSourceItem(string title)
        {
            base.InitializeDataSourceItem(title);
            Schema = "dbo";
            Properties.SetItem("ServerAggregation", true);
        }
    }
}
