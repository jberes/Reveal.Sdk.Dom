using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class SummarizationRegularField : SummarizationDimensionField
    {
        internal SummarizationRegularField() : this(string.Empty) { }

        public SummarizationRegularField(string fieldName) : base(fieldName)
        {
            SchemaTypeName = SchemaTypeNames.SummarizationRegularFieldType;
        }
    }
}
