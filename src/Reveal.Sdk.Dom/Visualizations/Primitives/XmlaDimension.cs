using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class XmlaDimension : XmlaDimensionElement
    {
        public XmlaDimension() 
        { 
            SchemaTypeName = SchemaTypeNames.XmlaDimensionType;
        }

        public string DefaultHierarchy { get; set; }
    }
}
