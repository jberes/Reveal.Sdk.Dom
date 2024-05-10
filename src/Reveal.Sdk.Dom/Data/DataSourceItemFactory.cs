using System;

namespace Reveal.Sdk.Dom.Data
{
    public interface IDataSourceItemFactory
    {
        IDataSourceBuilder Create(DataSourceType type, string title);
        IDataSourceBuilder Create(DataSourceType type, string title, string id);
        IDataSourceBuilder Create(DataSourceType type, DataSource dataSource, string title);
        IDataSourceBuilder Create(DataSourceType type, DataSource dataSource, string title, string id);
    }

    public class DataSourceItemFactory : IDataSourceItemFactory
    {
        public IDataSourceBuilder Create(DataSourceType type, string title)
        {
            return Create(type, title, null);
        }

        public IDataSourceBuilder Create(DataSourceType type, string title, string id)
        {
            return Create(type, null, title, id);
        }

        public IDataSourceBuilder Create(DataSourceType type, DataSource dataSource, string title)
        {
            return Create(type, dataSource, title, null);
        }

        public IDataSourceBuilder Create(DataSourceType type, DataSource dataSource, string title, string id)
        {

            return type switch
            {
                DataSourceType.MicrosoftSqlServer => new SqlBuilder(dataSource, title, id),
                DataSourceType.REST => new RestBuilder(dataSource, title, id),
                _ => throw new NotImplementedException($"No builder implemented for provider: {type}")
            };
        }
    }
}
