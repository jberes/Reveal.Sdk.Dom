using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    public class HostDatabaseSource : DatabaseSource
    {
        [JsonIgnore]
        public string Host
        {
            get => Properties.GetValue<string>("Host");
            set => Properties.SetItem("Host", value);
        }

        [JsonIgnore]
        public string Port
        {
            get => Properties.GetValue<string>("Port");
            set => Properties.SetItem("Port", value);
        }
    }
}
