using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    internal sealed class AdditionalTable
    {
        public string Alias { get; set; }
        public DataDefinitionBase DataSpec { get; set; }
        public List<JoinCondition> JoinConditions { get; set; }
        public AdditionalTable()
        {
            JoinConditions = new List<JoinCondition>();
        }
    }
}
