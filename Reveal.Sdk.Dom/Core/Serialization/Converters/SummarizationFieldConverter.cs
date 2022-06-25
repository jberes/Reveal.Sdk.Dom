using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class SummarizationFieldConverter : TypeMapConverter<SummarizationField>
    {
        public SummarizationFieldConverter()
        {
            TypeMap = new System.Collections.Generic.Dictionary<string, Type>()
            {
                { SchemaTypeNames.SummarizationDateFieldType, typeof(SummarizationDateField) },
                { SchemaTypeNames.SummarizationRegularFieldType, typeof(SummarizationRegularField) },
                { SchemaTypeNames.SummarizationValueFieldType, typeof(SummarizationValueField) }
            };
        }
    }
}
