using Reveal.Sdk.Dom.Core;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Serialization.Converters;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Visualizations.DataSpecs
{
    public class DataSpec : SchemaType
    {
        [JsonConverter(typeof(DataSourceItemConverter))]
        public DataSourceItem DataSourceItem { get; set; }
        public int Expiration { get; set; } = 1440;
        public DataSpecBindings Bindings { get; set; } = new DataSpecBindings();
    }
}
