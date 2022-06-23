using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Core
{
    public abstract class SchemaType
    {
        [JsonInclude]
        [JsonPropertyOrder(-1)]
        [JsonPropertyName("_type")]
        public string SchemaTypeName { get; internal set; }
    }
}
