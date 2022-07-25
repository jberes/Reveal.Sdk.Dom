using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class TextDataField : DimensionDataField
    {
        internal TextDataField() : this(string.Empty) { }

        public TextDataField(string fieldName) : base(fieldName)
        {
            SchemaTypeName = SchemaTypeNames.SummarizationRegularFieldType;
        }
    }
}
