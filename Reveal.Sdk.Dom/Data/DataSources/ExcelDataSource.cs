using Reveal.Sdk.Dom.Core.Constants;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Data
{
    public class ExcelDataSource : DataSource
    {
        [JsonIgnore]
        public string Url { get; set; }

        [JsonIgnore]
        public bool UseAnonymousAuthentication { get; set; } = true;

        public ExcelDataSource(string url)
        {
            Id = DataSourceIds.ExcelId;
            Provider = DataSourceProviders.ExcelProvider;
            Url = url;
        }
    }
}
