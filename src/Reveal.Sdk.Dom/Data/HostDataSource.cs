using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public class HostDataSource : DatabaseDataSource
    {
        [JsonIgnore]
        public string Host
        {
            get => Properties.GetValue<string>("Host");
            set => Properties.SetItem("Host", value);
        }

        [JsonIgnore]
        public int Port
        {
            get => Properties.GetValue<int>("Port");
            set => Properties.SetItem("Port", value);
        }
    }
}
