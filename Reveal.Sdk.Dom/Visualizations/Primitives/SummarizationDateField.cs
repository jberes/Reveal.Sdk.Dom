using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class SummarizationDateField : SummarizationDimensionField
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DateAggregationType DateAggregationType { get; set; } = DateAggregationType.Year;
        public DateFormattingSpec DateFormatting { get; set; }

        public SummarizationDateField() : this(string.Empty) { }

        public SummarizationDateField(string fieldName) : base(fieldName)
        {
            SchemaTypeName = SchemaTypeNames.SummarizationDateFieldType;
        }
    }
}
