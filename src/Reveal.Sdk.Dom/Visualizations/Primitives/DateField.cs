using Reveal.Sdk.Dom.Filters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class DateField : FieldBase<DateTimeFilter>
    {
        internal DateField() : this(string.Empty) { }
        public DateField(string fieldName) : base(fieldName)
        {
            ((IFieldDataType)this).DataType = DataType.Date;
        }
    }
}
