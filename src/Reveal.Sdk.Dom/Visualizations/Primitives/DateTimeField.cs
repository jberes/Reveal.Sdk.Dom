using Reveal.Sdk.Dom.Filters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class DateTimeField : FieldBase<DateTimeFilter>
    {
        internal DateTimeField() : this(string.Empty) { }
        public DateTimeField(string fieldName) : base(fieldName)
        {
            ((IFieldDataType)this).DataType = DataType.DateTime;
        }
    }
}
