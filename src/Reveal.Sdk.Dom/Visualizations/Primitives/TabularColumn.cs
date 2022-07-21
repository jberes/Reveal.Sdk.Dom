using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class TabularColumn : ColumnBase
    {
        internal TabularColumn() : this(string.Empty) { }
        public TabularColumn(string fieldName)
        {
            SchemaTypeName = SchemaTypeNames.TabularColumnSpecType;
            FieldName = fieldName;
        }
        
        /// <summary>
        /// Gets or sets the field name.
        /// </summary>
        public string FieldName { get; set; }
    }
}
