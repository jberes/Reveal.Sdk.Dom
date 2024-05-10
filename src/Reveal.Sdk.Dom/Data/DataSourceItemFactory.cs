using System;

namespace Reveal.Sdk.Dom.Data
{
    public interface IDataSourceItemFactory
    {
        IDataSourceBuilder Create(DataSourceType type, string title, string subtitle);
        IDataSourceBuilder Create(DataSourceType type, string title, string subtitle, DataSource datasource);
    }

    public class DataSourceItemFactory : IDataSourceItemFactory
    {
        public IDataSourceBuilder Create(DataSourceType type, string title, string subtitle)
        {
            return Create(type, title, subtitle, null);
        }

        public IDataSourceBuilder Create(DataSourceType type, string title, string subtitle, DataSource datasource)
        {

            return type switch
            {
                DataSourceType.MicrosoftSqlServer => new SqlBuilder(title, subtitle, datasource),
                DataSourceType.REST => new RestBuilder(title, subtitle, datasource),
                _ => throw new NotImplementedException($"No builder implemented for provider: {type}")
            };
        }
    }
}
