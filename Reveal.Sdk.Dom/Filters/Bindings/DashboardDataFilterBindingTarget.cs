using Reveal.Sdk.Dom.Core.Constants;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Filters
{
    public class DashboardDataFilterBindingTarget : BindingTarget
    {
        [JsonPropertyName("GlobalFilterId")]
        public string DashboardFilterId { get; set; }

        [JsonPropertyName("GlobalFilterFieldName")]
        public string DashboardFilterFieldName { get; set; }

        public DashboardDataFilterBindingTarget()
        {
            SchemaTypeName = SchemaTypeNames.DataBasedGlobalFilterBindingTargetType;
        }
    }
}
