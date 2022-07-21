using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class FormattingBase : SchemaType
    {
        //todo: is this used?
        [JsonProperty]
        internal bool OverrideDefaultSettings { get; set; }
    }
}
