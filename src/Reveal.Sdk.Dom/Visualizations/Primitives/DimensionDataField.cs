using Newtonsoft.Json;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{    
    public abstract class DimensionDataField : DataField, IDimensionDataField
    {
        public DimensionDataField(string fieldName) : base(fieldName) { }
        
        //todo: what is this used for?
        [JsonProperty]
        internal List<string> DrillDownElements { get; set; } = new List<string>();

        //used to visually expand hierachy in the vizualization, such as the pivot grid
        //todo: is this used by any other visualization?
        [JsonProperty]
        internal List<string> ExpandedItems { get; set; } = new List<string>();

        //todo: what is this used for?
        [JsonProperty]
        internal string SortByField { get; set; }
    }
}
