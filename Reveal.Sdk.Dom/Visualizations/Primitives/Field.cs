using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Core.Serialization.Converters;
using Reveal.Sdk.Dom.Filters;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    [JsonConverter(typeof(FieldConverter))]
    public abstract class Field
    {
        public string FieldName { get; set; }
        public string FieldLabel { get; set; }

        [JsonProperty("FieldType")]
        [JsonConverter(typeof(StringEnumConverter))]
        internal DataType DataType { get; set; } = DataType.String;
        public bool IsHidden { get; set; }
        public bool IsCalculated { get; set; }
        public string Expression { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SortingType Sorting { get; set; } = SortingType.None;

        public Filter Filter { get; set; }

        [JsonConverter(typeof(FormattingSpecConverter))]
        public FormattingSpec Formatting { get; set; }
        public ConditionalFormattingSpec ConditionalFormatting { get; set; }
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

    public class DateField : Field
    {
        internal DateField() : this(string.Empty) { }
        public DateField(string fieldName) : base(fieldName)
        {
            DataType = DataType.Date;
        }
    }

    public class NumberField : Field
    {
        internal NumberField() : this(string.Empty) { }
        public NumberField(string fieldName) : base(fieldName)
        {
            DataType = DataType.Number;
        }
    }

    public class DateTimeField : Field
    {
        internal DateTimeField() : this(string.Empty) { }
        public DateTimeField(string fieldName) : base(fieldName)
        {
            DataType = DataType.DateTime;
        }
    }

    public class TimeField : Field
    {
        internal TimeField() : this(string.Empty) { }
        public TimeField(string fieldName) : base(fieldName)
        {
            DataType = DataType.Time;
        }
    }

    public class TextField : Field
    {
        internal TextField() : this(string.Empty) { }
        public TextField(string fieldName) : base(fieldName)
        {
            DataType = DataType.String;
        }
    }
}
