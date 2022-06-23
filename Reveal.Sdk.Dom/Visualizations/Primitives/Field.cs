using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Serialization.Converters;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class Field
    {
        public string FieldName { get; set; }
        public string FieldLabel { get; set; }

        [JsonProperty("FieldType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataType DataType { get; set; } = DataType.String;
        public bool IsHidden { get; set; }
        public bool IsCalculated { get; set; }
        public string Expression { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SortingType Sorting { get; set; } = SortingType.None;

        public Filter Filter { get; set; }

        [JsonConverter(typeof(FormattingSpecConverter))]
        public FormattingSpec Formatting { get; set; }
        public ConditionalFormattingSpec ConditionalFormatting { get; set; }

        [JsonConverter(typeof(FieldSettingsConverter))]
        public FieldSettings Settings { get; set; }
        public string TableAlias { get; set; }
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();

        internal Field() : this(string.Empty) { }

        public Field(string fieldName)
        {
            FieldName = fieldName;
            FieldLabel = fieldName;
        }
    }
}
