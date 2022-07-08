using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Core
{
    public abstract class SchemaType
    {
        [JsonProperty("_type", Order = -2)]
        internal string SchemaTypeName { get; set; }
    }
}
