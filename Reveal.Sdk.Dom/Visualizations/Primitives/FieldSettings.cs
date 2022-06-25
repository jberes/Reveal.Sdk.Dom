using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core;
using Reveal.Sdk.Dom.Core.Serialization.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    [JsonConverter(typeof(FieldSettingsConverter))]
    public class FieldSettings : SchemaType
    {
    }
}
