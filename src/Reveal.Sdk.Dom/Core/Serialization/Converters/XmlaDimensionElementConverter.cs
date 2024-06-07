using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class XmlaDimensionElementConverter : TypeMapConverter<XmlaDimensionElement>
    {
        public XmlaDimensionElementConverter()
        {
            TypeMap = new Dictionary<string, Type>()
            {
                { SchemaTypeNames.XmlaDimensionType, typeof(XmlaDimension) },
                { SchemaTypeNames.XmlaHierarchyLevelType, typeof(XmlaHierarchyLevel) },
                { SchemaTypeNames.XmlaHierarchyType, typeof(XmlaHierarchy) },
                { SchemaTypeNames.XmlaSetType, typeof(XmlaSet) },
            };
        }
    }
}
