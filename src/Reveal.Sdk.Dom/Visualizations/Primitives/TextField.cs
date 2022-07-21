using Reveal.Sdk.Dom.Filters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class TextField : FieldBase<StringFilter>
    {
        internal TextField() : this(string.Empty) { }
        public TextField(string fieldName) : base(fieldName)
        {
            ((IFieldDataType)this).DataType = DataType.String;
        }
    }
}
