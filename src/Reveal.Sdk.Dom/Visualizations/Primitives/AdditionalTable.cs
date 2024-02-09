using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Serialization.Converters;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    internal sealed class AdditionalTable
    {
        public string Alias { get; set; }

        [JsonProperty("DataSpec")]
        [JsonConverter(typeof(DataSpecConverter))]
        public DataDefinitionBase DataDefinition { get; set; }

        public List<JoinCondition> JoinConditions { get; set; }
        public AdditionalTable()
        {
            JoinConditions = new List<JoinCondition>();
        }
    }
}
