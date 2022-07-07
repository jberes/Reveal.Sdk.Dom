namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IRowsExtensions
    {
        public static T AddRow<T>(this T visualization, string field)
            where T : IRows
        {
            return visualization.AddRow(new SummarizationRegularField(field));
        }

        public static T AddRow<T>(this T visualization, SummarizationDimensionField field)
            where T : IRows
        {
            visualization.Rows.Add(new DimensionColumnSpec()
            {
                SummarizationField = field,
            });
            return visualization;
        }

        public static T AddRows<T>(this T visualization, params string[] fields)
            where T : IRows
        {
            foreach (var field in fields)
            {
                visualization.AddRow(field);
            }    
            return visualization;
        }
    }
}
