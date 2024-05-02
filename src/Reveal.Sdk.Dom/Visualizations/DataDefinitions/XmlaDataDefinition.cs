using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class XmlaDataDefinition : DataDefinitionBase
    {
        public XmlaDataDefinition()
        {
            SchemaTypeName = SchemaTypeNames.XmlaDataSpecType;
        }

        public bool ShowGrandTotals { get; set; }
        public List<XmlaDimensionElement> Rows { get; set; } = new List<XmlaDimensionElement>();
        public List<XmlaDimensionElement> Columns { get; set; } = new List<XmlaDimensionElement>();
        public List<XmlaMeasure> Measures { get; set; } = new List<XmlaMeasure>();
        public List<XmlaDimensionElement> Filters { get; set; } = new List<XmlaDimensionElement>();
        public List<XmlaDimensionElement> DataFilters { get; set; } = new List<XmlaDimensionElement>();
    }
}
