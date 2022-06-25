using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class FormattingSpecConverter : TypeMapConverter<FormattingSpec>
    {
        public FormattingSpecConverter()
        {
            TypeMap = new System.Collections.Generic.Dictionary<string, Type>()
            {
                { SchemaTypeNames.NumberFormattingSpecType, typeof(NumberFormattingSpec) },
                { SchemaTypeNames.DateFormattingSpecType, typeof(DateFormattingSpec) }
            };
        }
    }
}
