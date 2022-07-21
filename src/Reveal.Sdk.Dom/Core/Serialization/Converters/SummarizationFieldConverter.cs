using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using System;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class DataFieldConverter : TypeMapConverter<IDataField>
    {
        public DataFieldConverter()
        {
            TypeMap = new System.Collections.Generic.Dictionary<string, Type>()
            {
                { SchemaTypeNames.SummarizationDateFieldType, typeof(DateDataField) },
                { SchemaTypeNames.SummarizationRegularFieldType, typeof(TextDataField) },
                { SchemaTypeNames.SummarizationValueFieldType, typeof(NumberDataField) }
            };
        }
    }
}
