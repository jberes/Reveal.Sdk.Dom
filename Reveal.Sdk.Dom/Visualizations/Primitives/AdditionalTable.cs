using Reveal.Sdk.Dom.Visualizations.DataSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class AdditionalTable
    {
        public string Alias { get; set; }
        public DataSpec DataSpec { get; set; }
        public List<JoinCondition> JoinConditions { get; set; }
        public AdditionalTable()
        {
            JoinConditions = new List<JoinCondition>();
        }
    }
}
