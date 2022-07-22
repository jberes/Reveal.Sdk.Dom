using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class DateDataField : DimensionDataField
    {
        internal DateDataField() : this(string.Empty) { }
        public DateDataField(string fieldName) : base(fieldName)
        {
            SchemaTypeName = SchemaTypeNames.SummarizationDateFieldType;
        }

        [JsonProperty("DateAggregationType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DateAggregationType AggregationType { get; set; } = DateAggregationType.Year;

        [JsonProperty("DateFormatting")]
        public DateFormatting Formatting { get; set; }
    }
}
