using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class FixedLineData : FixedLine
    {
        internal FixedLineData()
        {
            SchemaTypeName = SchemaTypeNames.FixedLineDataType;
            FixedLineType = FixedLineType.Data;
        }

        public FixedLineData(string fieldName) : this(new NumberDataField(fieldName), fieldName) { }

        public FixedLineData(string fieldName, string title) : this(new NumberDataField(fieldName), title) { }

        public FixedLineData(NumberDataField field) : this(field, field.FieldName) { }

        public FixedLineData(NumberDataField field, string title) : this()
        {
            DataField = new MeasureColumn(field);
            Title = title;
            Identifier = field?.FieldName;
        }

        //todo: one day we need to worry about XMLA
        [JsonProperty]
        internal MeasureColumn DataField { get; set; }
    }
}
