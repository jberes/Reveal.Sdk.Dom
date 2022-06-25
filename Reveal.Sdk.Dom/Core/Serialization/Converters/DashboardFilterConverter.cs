using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class DashboardFilterConverter : TypeMapConverter<DashboardFilter>
    {
        public DashboardFilterConverter()
        {
            TypeMap = new Dictionary<string, Type>()
            {
                { SchemaTypeNames.DateGlobalFilterType, typeof(DashboardDateFilter) },
                { SchemaTypeNames.TabularGlobalFilterType, typeof(DashboardDataFilter) },
            };
        }
    }
}
