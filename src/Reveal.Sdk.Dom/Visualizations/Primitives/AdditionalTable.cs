using Newtonsoft.Json;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class AdditionalTable
    {
        public string Alias { get; set; }

        [JsonProperty("DataSpec")]
        public IDataDefinition DataDefinition { get; set; }

        public List<JoinCondition> JoinConditions { get; set; }
        public AdditionalTable()
        {
            JoinConditions = new List<JoinCondition>();
        }
    }
}
