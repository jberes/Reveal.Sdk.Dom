namespace Reveal.Sdk.Dom.Filters
{
    public class DashboardDataFilterBinding : Binding<FieldBindingSource, DashboardDataFilterBindingTarget>
    {
        public DashboardDataFilterBinding() : this(null) { }

        public DashboardDataFilterBinding(DashboardDataFilter dataFilter)
        {
            Source = new FieldBindingSource() { FieldName = dataFilter?.SelectedFieldName };
            Operator = BindingOperatorType.Equals;
            Target = new DashboardDataFilterBindingTarget()
            {
                DashboardFilterId = dataFilter?.Id,
                DashboardFilterFieldName = dataFilter?.SelectedFieldName
            };
        }
    }
}
