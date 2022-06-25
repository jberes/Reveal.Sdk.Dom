using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class BindingSourceConverter : TypeMapConverter<BindingSource>
    {
        public BindingSourceConverter()
        {
            TypeMap = new System.Collections.Generic.Dictionary<string, Type>()
            {
                { SchemaTypeNames.FieldBindingSourceType, typeof(FieldBindingSource) },
                { SchemaTypeNames.ParameterBindingSourceType, typeof(ParameterBindingSource) },
            };
        }
    }
}
