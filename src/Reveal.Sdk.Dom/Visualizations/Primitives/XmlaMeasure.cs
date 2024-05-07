using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class XmlaMeasure : IMetadata
    {
        public XmlaMeasure()
        {
            Sorting = SortingType.None;
        }

        public bool IsHidden { get; set; }
        public string UniqueName { get; set; }
        public string Caption { get; set; }
        public string DisplayFolder { get; set; }
        public string MeasureGroupName { get; set; }
        public string UserCaption { get; set; }
        public bool IsCalculated { get; set; }
        public string Expression { get; set; }
        public NumberFormatting Formatting { get; set; }
        public ConditionalFormatting ConditionalFormatting { get; set; }
        [JsonIgnore]
        public string Description 
        { 
            get {return (string)(((IMetadata)this).Metadata.ContainsKey("Description") ? 
        ((IMetadata)this).Metadata["Description"] : null);} 
            internal set {((IMetadata)this).Metadata["Description"] = value;} 
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public SortingType Sorting { get; set; }
        [JsonProperty("Metadata")]
        Dictionary<string, object> IMetadata.Metadata  { get; set; } = new Dictionary<string,object>();
    }
}