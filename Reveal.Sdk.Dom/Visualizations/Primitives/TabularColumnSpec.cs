using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class TabularColumnSpec : ColumnSpec
    {
        public string FieldName { get; set; }

        public TabularColumnSpec()
        {
            SchemaTypeName = SchemaTypeNames.TabularColumnSpecType;
        }
    }
}
