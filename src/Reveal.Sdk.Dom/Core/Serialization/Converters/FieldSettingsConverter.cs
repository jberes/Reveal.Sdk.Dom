using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using System;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class FieldSettingsConverter : TypeMapConverter<FieldSettings>
    {
        public FieldSettingsConverter()
        {
            TypeMap = new System.Collections.Generic.Dictionary<string, Type>()
            {
                { SchemaTypeNames.DateTimeFieldSettingsType, typeof(DateTimeFieldSettings) }
            };
        }
    }
}
