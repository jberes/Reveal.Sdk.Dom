using Reveal.Sdk.Dom.Core;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class SummarizationField : SchemaType
    {
        public string FieldName { get; set; }
        public string Description { get; set; }

        internal SummarizationField() { }

        public SummarizationField(string fieldName)
        {
            FieldName = fieldName;
        }
    }
}
