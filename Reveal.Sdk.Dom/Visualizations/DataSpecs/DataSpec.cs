using Reveal.Sdk.Dom.Core;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Primitives;

namespace Reveal.Sdk.Dom.Visualizations.DataSpecs
{
    public class DataSpec : SchemaType
    {
        public DataSourceItem DataSourceItem { get; set; }
        public int Expiration { get; set; } = 1440;
        public DataSpecBindings Bindings { get; set; } = new DataSpecBindings();
    }
}
