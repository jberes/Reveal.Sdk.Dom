namespace Reveal.Sdk.Dom.Filters
{
    public class DashboardDateFilterBinding : Binding<FieldBindingSource, DashboardDateFilterBindingTarget>
    {
        internal DashboardDateFilterBinding() : this(string.Empty) { }

        public DashboardDateFilterBinding(string fieldName)
        {
            Operator = BindingOperatorType.Between;
            Source = new FieldBindingSource() { FieldName = fieldName };
            Target = new DashboardDateFilterBindingTarget();
        }
    }
}
