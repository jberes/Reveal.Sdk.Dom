using Newtonsoft.Json;
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
        public string Body { get; set; }

        [JsonIgnore]
        public string ContentType { get; set; }

        [JsonIgnore]
        public List<string> Headers { get; set; }

        [JsonIgnore]
        public string Method { get; set; }
    }
}
