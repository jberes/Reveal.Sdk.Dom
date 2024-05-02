using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class XmlaHierarchy : XmlaDimensionElement
    {
        public XmlaHierarchy() 
        { 
            SchemaTypeName = SchemaTypeNames.XmlaHierarchyType;
        }

        public int Origin { get; set; }
        public string Description { get; set; }
        public int? Cardinality { get; set; }
        public string DisplayFolder { get; set; }
        public string AllMember { get; set; }
        public string DefaultMember { get; set; }
    }
}
