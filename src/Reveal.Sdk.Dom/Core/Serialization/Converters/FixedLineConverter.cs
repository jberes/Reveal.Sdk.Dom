using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class FixedLineConverter : TypeMapConverter<IFixedLine>
    {
        public FixedLineConverter()
        {
            TypeMap = new Dictionary<string, Type>()
            {
                { SchemaTypeNames.FixedLineAverageType, typeof(FixedLineAverage) },
                { SchemaTypeNames.FixedLineDataType, typeof(FixedLineData) },
                { SchemaTypeNames.FixedLineFixedValueType, typeof(FixedLineFixedValue) },
                { SchemaTypeNames.FixedLineHighestType, typeof(FixedLineMaximum) },
                { SchemaTypeNames.FixedLineLowestType, typeof(FixedLineMinimum) }
            };
        }
    }
}
