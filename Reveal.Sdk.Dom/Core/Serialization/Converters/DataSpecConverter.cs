using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.DataSpecs;
using System;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class DataSpecConverter : TypeMapConverter<DataSpec>
    {
        public DataSpecConverter()
        {
            TypeMap = new System.Collections.Generic.Dictionary<string, Type>()
            {
                { SchemaTypeNames.TabularDataSpecType, typeof(TabularDataSpec)},
                //{ SchemaTypeNames.ResourceDataSpecType, typeof()},
                //{ SchemaTypeNames.ResourceDataSpecType, typeof()},
                //{ SchemaTypeNames.ResourceDataSpecType, typeof()},
            };
        }
    }
}
