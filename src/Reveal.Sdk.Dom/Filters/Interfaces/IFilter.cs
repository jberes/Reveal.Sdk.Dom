using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Serialization.Converters;

namespace Reveal.Sdk.Dom.Filters
{
    [JsonConverter(typeof(FilterConverter))]
    public interface IFilter
    {

    }
}