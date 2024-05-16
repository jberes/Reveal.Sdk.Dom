using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public class MicrosoftSqlServerDataSource : DataSource
    {
        public MicrosoftSqlServerDataSource()
        {
            Provider = DataSourceProvider.MicrosoftSqlServer;
            Properties.SetItem("ServerAggregationDefault", true);
            Properties.SetItem("ServerAggregationReadOnly", false);
        }

        [JsonIgnore]
        public string Database
        {
            get => Properties.GetValue<string>("Database");
            set => Properties.SetItem("Database", value);
        }

        [JsonIgnore]
        public string Host
        {
            get => Properties.GetValue<string>("Host");
            set => Properties.SetItem("Host", value);
        }

        [JsonIgnore]
        public string Port
        {
            get => Properties.GetValue<string>("Port");
            set => Properties.SetItem("Port", value);
        }

        [JsonIgnore]
        public string Schema
        {
            get => Properties.GetValue<string>("Schema");
            set => Properties.SetItem("Schema", value);
        }

        internal static MicrosoftSqlServerDataSource Create(DataSource dataSource)
        {
            return new MicrosoftSqlServerDataSource()
            {
                Id = dataSource.Id,
                Title = dataSource.Title,
                Subtitle = dataSource.Subtitle,
            };
        }
    }
}
