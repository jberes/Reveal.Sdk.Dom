using Reveal.Sdk.Dom.Filters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class TimeField : FieldBase<TimeFilter>
    {
        internal TimeField() : this(string.Empty) { }
        public TimeField(string fieldName) : base(fieldName)
        {
            ((IFieldDataType)this).DataType = DataType.Time;
        }
    }
}
