using Newtonsoft.Json;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{    
    public abstract class DimensionDataField : DataField, IDimensionDataField
    {
        public DimensionDataField(string fieldName) : base(fieldName) { }
        
        [JsonProperty]
        internal List<string> DrillDownElements { get; set; } = new List<string>();

        //used to visually expand hierachy in the vizualization, only used by the pivot grid
        [JsonProperty]
        internal List<string> ExpandedItems { get; set; } = new List<string>();

        [JsonProperty]
        internal string SortByField { get; set; }
    }
}
