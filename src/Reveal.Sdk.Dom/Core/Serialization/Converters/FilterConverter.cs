using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;
using System;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class FilterConverter : TypeMapConverter<IFilter>
    {
        public FilterConverter()
        {
            TypeMap = new System.Collections.Generic.Dictionary<string, Type>()
            {
                { SchemaTypeNames.NumberFilterType, typeof(NumberFilter) },
                { SchemaTypeNames.StringFilterType, typeof(TextFilter) },
                { SchemaTypeNames.DateTimeFilterType, typeof(DateTimeFilter) },
                { SchemaTypeNames.TimeFilterType, typeof(TimeFilter) },
            };
        }
    }
}
