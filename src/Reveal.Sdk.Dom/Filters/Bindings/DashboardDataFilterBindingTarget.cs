using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Filters
{
    public sealed class DashboardDataFilterBindingTarget : BindingTarget
    {
        [JsonProperty("GlobalFilterId")]
        public string DashboardFilterId { get; set; }

        [JsonProperty("GlobalFilterFieldName")]
        public string DashboardFilterFieldName { get; set; }

        public DashboardDataFilterBindingTarget()
        {
            SchemaTypeName = SchemaTypeNames.DataBasedGlobalFilterBindingTargetType;
        }
    }
}
