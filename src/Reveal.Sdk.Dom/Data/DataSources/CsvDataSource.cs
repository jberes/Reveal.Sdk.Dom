using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Data
{
    internal class CsvDataSource : DataSource
    {
        public CsvDataSource()
        {
            Id = DataSourceIds.CSV;
            Provider = DataSourceProvider.CSV;
        }
    }
}
