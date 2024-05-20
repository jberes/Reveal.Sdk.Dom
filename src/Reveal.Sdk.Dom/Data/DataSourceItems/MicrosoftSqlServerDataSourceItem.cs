using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public class MicrosoftSqlServerDataSourceItem : ProcedureDataSourceItem
    {
        public MicrosoftSqlServerDataSourceItem(string title, MicrosoftSqlServerDataSource dataSource) :
            base(title, dataSource)
        { }

        public MicrosoftSqlServerDataSourceItem(string title, string table, MicrosoftSqlServerDataSource dataSource) :
            base(title, dataSource)
        {
            Table = table;
        }

        internal MicrosoftSqlServerDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        protected override void InitializeDataSource(DataSource dataSource, string title)
        {
            //todo: make generic and place in base class
            if (!(dataSource is MicrosoftSqlServerDataSource))
            {
                var ds = MicrosoftSqlServerDataSource.Create(dataSource);
                dataSource = ds;
            }

            base.InitializeDataSource(dataSource, title);
        }

        override protected void InitializeDataSourceItem(string title)
        {
            base.InitializeDataSourceItem(title);
            Properties.SetItem("ServerAggregation", true);
        }
    }
}
