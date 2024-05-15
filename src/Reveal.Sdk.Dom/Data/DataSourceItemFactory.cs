using System;

namespace Reveal.Sdk.Dom.Data
{
    public interface IDataSourceItemFactory
    {
        DataSourceItem Create(DataSourceType type, string title);

        DataSourceItem Create(DataSourceType type, DataSource dataSource, string title);
    }

    public class DataSourceItemFactory : IDataSourceItemFactory
    {
        public DataSourceItem Create(DataSourceType type, string title)
        {
            return Create(type, new DataSource(), title);
        }

        public DataSourceItem Create(DataSourceType type, DataSource dataSource, string title)
        {
            return type switch
            {
                DataSourceType.MicrosoftSqlServer => new MicrosoftSqlServerDataSourceItem(dataSource, title),
                DataSourceType.REST => new RestDataSourceItem(dataSource, title),
                _ => throw new NotImplementedException($"No builder implemented for provider: {type}")
            };
        }
    }
}
