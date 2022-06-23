namespace Reveal.Sdk.Dom.Filters
{
    public class DashboardDateFilterBinding : Binding<FieldBindingSource, DashboardDateFilterBindingTarget>
    {
        public DashboardDateFilterBinding() : this("Date") { }

        public DashboardDateFilterBinding(string fieldName)
        {
            Operator = BindingOperatorType.Between;
            Source = new FieldBindingSource() { FieldName = fieldName };
            Target = new DashboardDateFilterBindingTarget();
        }
    }
}
