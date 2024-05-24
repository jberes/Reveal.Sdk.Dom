using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;
using System;

namespace Reveal.Sdk.Dom.Data
{
    public class MicrosoftSqlServerDataSourceItem : ProcedureDataSourceItem, IProcessDataOnServer
    {
        public MicrosoftSqlServerDataSourceItem(string title, string table, MicrosoftSqlServerDataSource dataSource) :
            this(title, dataSource)
        {
            Table = table;
        }

        public MicrosoftSqlServerDataSourceItem(string title, MicrosoftSqlServerDataSource dataSource) :
            base(title, dataSource)
        { }

        internal MicrosoftSqlServerDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public bool ProcessDataOnServer
        {
            get => Properties.GetValue<bool>("ServerAggregation");
            set => Properties.SetItem("ServerAggregation", value);
        }

        protected override DataSource CreateDataSourceInstance(DataSource dataSource)
        {
            return Create<MicrosoftSqlServerDataSource>(dataSource);
        }
    }
}
