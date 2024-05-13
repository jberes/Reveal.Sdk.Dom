using System;

namespace Reveal.Sdk.Dom.Data
{
    public interface IDataSourceItemFactory
    {
        IDataSourceItemBuilder Create(DataSourceType type, string title);

        IDataSourceItemBuilder Create(DataSourceType type, DataSource dataSource, string title);
    }

    public class DataSourceItemFactory : IDataSourceItemFactory
    {
        public IDataSourceItemBuilder Create(DataSourceType type, string title)
        {
            return Create(type, new DataSource(), title);
        }

        public IDataSourceItemBuilder Create(DataSourceType type, DataSource dataSource, string title)
        {
            return type switch
            {
                DataSourceType.MicrosoftSqlServer => new SqlDataSourceItemBuilder(dataSource, title),
                DataSourceType.REST => new RestDataSourceItemBuilder(dataSource, title),
                _ => throw new NotImplementedException($"No builder implemented for provider: {type}")
            };
        }
    }
}
