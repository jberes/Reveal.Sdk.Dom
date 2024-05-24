using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    internal class GoogleBigQueryDataSource : DatabaseDataSource
    {
        public GoogleBigQueryDataSource()
        {
            Provider = DataSourceProvider.GoogleBigQuery;
        }

        [JsonIgnore]
        public string ProjectId
        {
            get => Properties.GetValue<string>("ProjectId");
            set => Properties.SetItem("ProjectId", value);
        }
    }
}
