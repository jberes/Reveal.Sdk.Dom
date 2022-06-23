using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Serialization.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class SummarizationValueField : SummarizationField
    {
        public string FieldLabel { get; set; }
        public bool IsHidden { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public AggregationType AggregationType { get; set; } = AggregationType.Sum;

        [JsonConverter(typeof(StringEnumConverter))]
        public SortingType Sorting { get; set; } = SortingType.None;
        public bool IsCalculated { get; set; }
        public string Expression { get; set; }

        [JsonConverter(typeof(FormattingSpecConverter))]
        public FormattingSpec Formatting { get; set; }
        public ConditionalFormattingSpec ConditionalFormatting { get; set; }
        public Filter Filter { get; set; }

        public SummarizationValueField() : this(string.Empty) { }

        public SummarizationValueField(string fieldName) : base(fieldName)
        {
            SchemaTypeName = SchemaTypeNames.SummarizationValueFieldType;
            FieldLabel = fieldName;
        }
    }
}
