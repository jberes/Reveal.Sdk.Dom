using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    internal class AmazonS3DataSource : DataSource
    {
        public AmazonS3DataSource()
        {
            Provider = DataSourceProvider.AmazonS3;
        }

        [JsonIgnore]
        public string AccountId
        {
            get => Properties.GetValue<string>("AccountId");
            set => Properties.SetItem("AccountId", value);
        }

        [JsonIgnore]
        public string Region
        {
            get => Properties.GetValue<string>("Region");
            set => Properties.SetItem("Region", value);
        }
    }
}
