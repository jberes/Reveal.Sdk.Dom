using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class NumberDataField : DataField
    {
        internal NumberDataField() : this(string.Empty) { }
        public NumberDataField(string fieldName) : base(fieldName)
        {
            SchemaTypeName = SchemaTypeNames.SummarizationValueFieldType;
            FieldLabel = fieldName;
        }

        private string _fieldLabel;
        public string FieldLabel
        {
            get => _fieldLabel;
            set
            {
                _fieldLabel = value;
                UserCaption = value;
            }
        }

        /// <summary>
        /// The UserCaption is used to display a custom label in the UI. 
        /// However, the FieldLabel is also used to display a custom label in the UI and is generated from the data provides if it exists.
        /// To simplify the API, we are using the FieldLabel as the primary label and hiding UserCaption from the public API
        /// </summary>
        [JsonProperty]
        internal string UserCaption { get; set; }

        [JsonProperty]
        public bool IsHidden { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public AggregationType AggregationType { get; set; } = AggregationType.Sum;

        [JsonConverter(typeof(StringEnumConverter))]
        public SortingType Sorting { get; set; } = SortingType.None;
        
        public bool IsCalculated { get; set; }
        
        public string Expression { get; set; }

        public NumberFormatting Formatting { get; set; }
        
        public ConditionalFormatting ConditionalFormatting { get; set; }

        [JsonProperty]
        internal NumberFilter Filter { get; set; }
    }
}
