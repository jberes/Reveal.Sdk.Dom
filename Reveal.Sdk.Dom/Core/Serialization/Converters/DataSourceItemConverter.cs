using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Data;
using System;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class DataSourceItemConverter : TypeMapConverter<DataSourceItem>
    {
        public DataSourceItemConverter()
        {
            TypeMap = new System.Collections.Generic.Dictionary<string, Type>()
            {
                { SchemaTypeNames.CompositeDataSourceItemType, typeof(CompositeDataSourceItem) },
                { SchemaTypeNames.DataSourceItemType, typeof(DataSourceItem) }
            };
        }
    }
}
