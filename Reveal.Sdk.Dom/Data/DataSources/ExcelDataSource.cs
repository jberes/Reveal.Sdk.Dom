using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    public class ExcelDataSource : DataSource
    {
        [JsonIgnore]
        public string Url { get; set; }

        [JsonIgnore]
        public bool UseAnonymousAuthentication { get; set; } = true;

        internal ExcelDataSource() : this(string.Empty) { }

        public ExcelDataSource(string url) : base()
        {
            Id = DataSourceIds.ExcelId;
            Provider = DataSourceProviders.ExcelProvider;
            Url = url;
        }
    }
}
