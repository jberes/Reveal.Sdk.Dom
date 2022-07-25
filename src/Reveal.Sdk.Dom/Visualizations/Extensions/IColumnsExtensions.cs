namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IColumnsExtensions
    {
        public static T SetColumn<T>(this T visualization, string field)
            where T : IColumns
        {
            visualization.SetColumn(new TextDataField(field));
            return visualization;
        }

        public static T SetColumn<T>(this T visualization, DimensionDataField field)
            where T : IColumns
        {
            visualization.Columns.Clear();
            visualization.Columns.Add(new DimensionColumn()
            {
                DataField = field,
            });
            return visualization;
        }

        public static T SetColumns<T>(this T visualization, params string[] fields)
            where T : IColumns
        {
            visualization.Columns.Clear();
            foreach (var field in fields)
            {
                visualization.Columns.Add(new DimensionColumn()
                {
                    DataField = new TextDataField(field),
                });
            }
            return visualization;
        }

        public static T SetColumns<T>(this T visualization, params DimensionDataField[] fields)
            where T : IColumns
        {
            visualization.Columns.Clear();
            foreach (var field in fields)
            {
                visualization.Columns.Add(new DimensionColumn()
                {
                    DataField = field,
                });
            }
            return visualization;
        }
    }
}
