using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class SummarizationDateField : SummarizationDimensionField
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public DateAggregationType DateAggregationType { get; set; } = DateAggregationType.Year;
        public DateFormattingSpec DateFormatting { get; set; }

        internal SummarizationDateField() : this(string.Empty) { }

        public SummarizationDateField(string fieldName) : base(fieldName)
        {
            SchemaTypeName = SchemaTypeNames.SummarizationDateFieldType;
        }
    }
}
