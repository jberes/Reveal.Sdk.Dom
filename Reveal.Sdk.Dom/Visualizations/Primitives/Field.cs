using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Serialization.Converters;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class Field
    {
        public string FieldName { get; set; }
        public string FieldLabel { get; set; }

        [JsonPropertyName("FieldType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DataType DataType { get; set; } = DataType.String;
        public bool IsHidden { get; set; }
        public bool IsCalculated { get; set; }
        public string Expression { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SortingType Sorting { get; set; } = SortingType.None;

        [JsonConverter(typeof(FilterConverter))]
        public Filter Filter { get; set; }

        [JsonConverter(typeof(FormattingSpecConverter))]
        public FormattingSpec Formatting { get; set; }
        public ConditionalFormattingSpec ConditionalFormatting { get; set; }

        [JsonConverter(typeof(FieldSettingsConverter))]
        public FieldSettings Settings { get; set; }
        public string TableAlias { get; set; }
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();

        public Field() : this(string.Empty) { }

        public Field(string fieldName)
        {
            FieldName = fieldName;
            FieldLabel = fieldName;
        }
    }
}
