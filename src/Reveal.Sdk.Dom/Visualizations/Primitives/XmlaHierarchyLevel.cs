using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class XmlaHierarchyLevel : XmlaDimensionElement
    {
        public XmlaHierarchyLevel() 
        {
            SchemaTypeName = SchemaTypeNames.XmlaHierarchyLevelType;
        }

        public string HierarchyUniqueName { get; set; }
        public int LevelNumber { get; set; }
        public int Cardinality { get; set; }
    }
}
