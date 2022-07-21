namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ITabularColumnsExtensions
    {
        public static T SetColumns<T>(this T visualization, params string[] fields)
            where T : ITabularColumns
        {
            visualization.Columns.Clear();
            foreach (var field in fields)
            {
                visualization.Columns.Add(new TabularColumn(field));
            }
            return visualization;
        }
    }
}
