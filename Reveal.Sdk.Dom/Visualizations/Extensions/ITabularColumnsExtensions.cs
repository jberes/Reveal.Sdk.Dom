namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ITabularColumnsExtensions
    {
        public static T AddColumn<T>(this T visualization, string field)
            where T : ITabularColumns
        {
            visualization.Columns.Add(new TabularColumnSpec()
            {
                FieldName = field
            });
            return visualization;
        }

        public static T AddColumn<T>(this T visualization, params string[] fields)
            where T : ITabularColumns
        {
            foreach (var field in fields)
            {
                visualization.AddColumn(field);
            }
            return visualization;
        }
    }
}
