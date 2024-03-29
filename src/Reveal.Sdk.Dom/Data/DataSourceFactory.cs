using System;

namespace Reveal.Sdk.Dom.Data
{
    public class DataSourceFactory
    {
        public static IDataSourceBuilder Create(DataSourceType type, string title, string subtitle)
        {
            return type switch
            {
                DataSourceType.RemoteFile => new RemoteFileBuilder(title, subtitle),
                DataSourceType.REST => new RestBuilder(title, subtitle),
                //DataSourceType.MicrosoftSqlServer => new SqlServerBuilder("", "", ""),
                _ => throw new NotImplementedException($"No builder implemented for provider: {type}")
            };
        }
    }
}
