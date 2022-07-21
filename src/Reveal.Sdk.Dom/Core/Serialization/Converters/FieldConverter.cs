using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class FieldConverter : TypeMapConverter<IField>
    {
        public FieldConverter() : base("FieldType")
        {
            TypeMap = new Dictionary<string, Type>()
            {
                { nameof(DataType.Date), typeof(DateField) },
                { nameof(DataType.DateTime), typeof(DateTimeField) },
                { nameof(DataType.Number), typeof(NumberField) },
                { nameof(DataType.Time), typeof(TimeField) },
                { nameof(DataType.String), typeof(TextField) },
            };
        }
    }
}
