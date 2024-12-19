using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public class GoogleBigQueryDataSource : DatabaseDataSource
    {
        public GoogleBigQueryDataSource()
        {
            Provider = DataSourceProvider.GoogleBigQuery;
        }

        [JsonIgnore]
        public string ProjectId
        {
            get => Properties.GetValue<string>("projectId");
            set => Properties.SetItem("projectId", value);
        }
    }
}
