using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Data
{
    internal class JsonDataSource : DataSource
    {
        public JsonDataSource()
        {
            Id = DataSourceIds.JSON;
            Provider = DataSourceProvider.JSON;
        }
    }
}
