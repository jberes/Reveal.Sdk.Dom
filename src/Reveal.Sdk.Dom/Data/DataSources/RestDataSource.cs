using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Data
{
    //todo: not sure this will ever be needed. a rest DS can only point to one URL and it doesn't really make sense to have a rest DS
    //when everything can be done in the rest DS item. This might be needed to simplify the creation of the REST DS item, so to copy properties
    //to different DS/DSI schema properties
    internal class RestDataSource : ODataDataSource
    {
        public RestDataSource()
        {
            Provider = DataSourceProvider.REST;
        }

        [JsonIgnore]
        public string Body
        {
            get => Properties.GetValue<string>("Body");
            set => Properties.SetItem("Body", value);
        }

        [JsonIgnore]
        public string ContentType
        {
            get => Properties.GetValue<string>("ContentType");
            set => Properties.SetItem("ContentType", value);
        }

        [JsonIgnore]
        public List<string> Headers
        {
            get => Properties.GetValue<List<string>>("Headers");
            set => Properties.SetItem("Headers", value);
        }

        [JsonIgnore]
        public string Method
        {
            get => Properties.GetValue<string>("Method");
            set => Properties.SetItem("Method", value);
        }
    }
}
