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
                { "XmlaDimensionType", typeof(XmlaDimension) },
                { "XmlaHierarchyLevelType", typeof(XmlaHierarchyLevel) },
                { "XmlaHierarchyType", typeof(XmlaHierarchy) },
                { "XmlaSetType", typeof(XmlaSet) },
            };
        }
    }
}
