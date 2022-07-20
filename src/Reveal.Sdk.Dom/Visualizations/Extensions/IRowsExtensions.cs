namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IRowsExtensions
    {
        public static T SetRow<T>(this T visualization, string field)
            where T : IRows
        {
            return visualization.SetRow(new SummarizationRegularField(field));
        }

        public static T SetRow<T>(this T visualization, SummarizationDimensionField field)
            where T : IRows
        {
            visualization.Rows.Clear();
            visualization.Rows.Add(new DimensionColumnSpec()
            {
                SummarizationField = field,
            });
            return visualization;
        }

        public static T SetRows<T>(this T visualization, params string[] fields)
            where T : IRows
        {
            visualization.Rows.Clear();
            foreach (var field in fields)
            {
                visualization.Rows.Add(new DimensionColumnSpec()
                {
                    SummarizationField = new SummarizationRegularField(field),
                });
            }    
            return visualization;
        }

        public static T SetRows<T>(this T visualization, params SummarizationDimensionField[] fields)
            where T : IRows
        {
            visualization.Rows.Clear();
            foreach (var field in fields)
            {
                visualization.Rows.Add(new DimensionColumnSpec()
                {
                    SummarizationField = field,
                });
            }
            return visualization;
        }
    }
}
