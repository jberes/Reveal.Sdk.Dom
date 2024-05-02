using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Serialization.Converters;
using Reveal.Sdk.Dom.Data;

namespace Reveal.Sdk.Dom.Visualizations
{
    [JsonConverter(typeof(DataSpecConverter))]
    public interface IDataDefinition
    {
        /// <summary>
        /// Gets or sets the expiration time in minutes for the data cache.
        /// </summary>
        int CacheExpiration { get; set; }


        DataSourceItem DataSourceItem { get; }
    }
}
