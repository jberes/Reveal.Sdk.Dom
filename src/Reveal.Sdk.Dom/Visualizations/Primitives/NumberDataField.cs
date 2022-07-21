using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class NumberDataField : DataField
    {
        internal NumberDataField() : this(string.Empty) { }
        public NumberDataField(string fieldName) : base(fieldName)
        {
            SchemaTypeName = SchemaTypeNames.SummarizationValueFieldType;
            FieldLabel = fieldName;
        }
        
        public string FieldLabel { get; set; }
        
        //todo: is this used?
        //public bool IsHidden { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public AggregationType AggregationType { get; set; } = AggregationType.Sum;

        [JsonConverter(typeof(StringEnumConverter))]
        public SortingType Sorting { get; set; } = SortingType.None;
        
        public bool IsCalculated { get; set; }
        
        public string Expression { get; set; }

        public NumberFormattingSpec Formatting { get; set; }
        
        public ConditionalFormattingSpec ConditionalFormatting { get; set; }
        
        public NumberFilter Filter { get; set; }
    }
}
