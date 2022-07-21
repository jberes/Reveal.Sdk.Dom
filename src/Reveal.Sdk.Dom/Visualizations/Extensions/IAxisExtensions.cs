namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IAxisExtensions
    {
        public static T SetXAxis<T>(this T visualization, string field)
            where T : IAxis
        {
            return visualization.SetXAxis(new NumberDataField(field));
        }

        public static T SetXAxis<T>(this T visualization, NumberDataField field)
            where T : IAxis
        {
            visualization.XAxes.Clear();
            visualization.XAxes.Add(new MeasureColumn()
            {
                DataField = field
            });
            return visualization;
        }

        public static T SetXAxes<T>(this T visualization, params string[] fields)
            where T : IAxis
        {
            visualization.XAxes.Clear();
            foreach (var field in fields)
            {
                visualization.XAxes.Add(new MeasureColumn()
                {
                    DataField = new NumberDataField(field)
                });
            }
            return visualization;
        }

        public static T SetXAxes<T>(this T visualization, params NumberDataField[] fields)
            where T : IAxis
        {
            visualization.XAxes.Clear();
            foreach (var field in fields)
            {
                visualization.XAxes.Add(new MeasureColumn()
                {
                    DataField = field
                });
            }
            return visualization;
        }

        public static T SetYAxis<T>(this T visualization, string field)
            where T : IAxis
        {
            return visualization.SetYAxis(new NumberDataField(field));
        }

        public static T SetYAxis<T>(this T visualization, NumberDataField field)
            where T : IAxis
        {
            visualization.YAxes.Clear();
            visualization.YAxes.Add(new MeasureColumn()
            {
                DataField = field
            });
            return visualization;
        }

        public static T SetYAxes<T>(this T visualization, params string[] fields)
            where T : IAxis
        {
            visualization.YAxes.Clear();
            foreach (var field in fields)
            {
                visualization.YAxes.Add(new MeasureColumn()
                {
                    DataField = new NumberDataField(field)
                });
            }
            return visualization;
        }

        public static T SetYAxes<T>(this T visualization, params NumberDataField[] fields)
            where T : IAxis
        {
            visualization.YAxes.Clear();
            foreach (var field in fields)
            {
                visualization.YAxes.Add(new MeasureColumn()
                {
                    DataField = field
                });
            }
            return visualization;
        }
    }
}
