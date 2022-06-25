using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;
using System;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class FilterConverter : TypeMapConverter<Filter>
    {
        public FilterConverter()
        {
            TypeMap = new System.Collections.Generic.Dictionary<string, Type>()
            {
                { SchemaTypeNames.NumberFilterType, typeof(NumberFilter) },
                { SchemaTypeNames.StringFilterType, typeof(StringFilter) },
                { SchemaTypeNames.DateTimeFilterType, typeof(DateTimeFilter) }
            };
        }
    }
}
