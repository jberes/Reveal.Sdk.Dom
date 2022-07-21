namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IRowsExtensions
    {
        public static T SetRow<T>(this T visualization, string field)
            where T : IRows
        {
            return visualization.SetRow(new TextDataField(field));
        }

        public static T SetRow<T>(this T visualization, DimensionDataField field)
            where T : IRows
        {
            visualization.Rows.Clear();
            visualization.Rows.Add(new DimensionColumn()
            {
                DataField = field,
            });
            return visualization;
        }

        public static T SetRows<T>(this T visualization, params string[] fields)
            where T : IRows
        {
            visualization.Rows.Clear();
            foreach (var field in fields)
            {
                visualization.Rows.Add(new DimensionColumn()
                {
                    DataField = new TextDataField(field),
                });
            }    
            return visualization;
        }

        public static T SetRows<T>(this T visualization, params DimensionDataField[] fields)
            where T : IRows
        {
            visualization.Rows.Clear();
            foreach (var field in fields)
            {
                visualization.Rows.Add(new DimensionColumn()
                {
                    DataField = field,
                });
            }
            return visualization;
        }
    }
}
