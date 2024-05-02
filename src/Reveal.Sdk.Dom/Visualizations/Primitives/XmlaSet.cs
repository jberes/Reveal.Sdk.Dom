using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class XmlaSet : XmlaDimensionElement
    {
        public XmlaSet() 
        { 
            SchemaTypeName = SchemaTypeNames.XmlaSetType;
        }

        public string HierarchyUniqueName { get; set; }
        public string DisplayFolder { get; set; }
    }
}
