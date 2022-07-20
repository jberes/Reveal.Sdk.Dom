namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IAxisExtensions
    {
        public static T SetXAxis<T>(this T visualization, string field)
            where T : IAxis
        {
            return visualization.SetXAxis(new SummarizationValueField(field));
        }

        public static T SetXAxis<T>(this T visualization, SummarizationValueField field)
            where T : IAxis
        {
            visualization.XAxes.Clear();
            visualization.XAxes.Add(new MeasureColumnSpec()
            {
                SummarizationField = field
            });
            return visualization;
        }

        public static T SetXAxes<T>(this T visualization, params string[] fields)
            where T : IAxis
        {
            visualization.XAxes.Clear();
            foreach (var field in fields)
            {
                visualization.XAxes.Add(new MeasureColumnSpec()
                {
                    SummarizationField = new SummarizationValueField(field)
                });
            }
            return visualization;
        }

        public static T SetXAxes<T>(this T visualization, params SummarizationValueField[] fields)
            where T : IAxis
        {
            visualization.XAxes.Clear();
            foreach (var field in fields)
            {
                visualization.XAxes.Add(new MeasureColumnSpec()
                {
                    SummarizationField = field
                });
            }
            return visualization;
        }

        public static T SetYAxis<T>(this T visualization, string field)
            where T : IAxis
        {
            return visualization.SetYAxis(new SummarizationValueField(field));
        }

        public static T SetYAxis<T>(this T visualization, SummarizationValueField field)
            where T : IAxis
        {
            visualization.YAxes.Clear();
            visualization.YAxes.Add(new MeasureColumnSpec()
            {
                SummarizationField = field
            });
            return visualization;
        }

        public static T SetYAxes<T>(this T visualization, params string[] fields)
            where T : IAxis
        {
            visualization.YAxes.Clear();
            foreach (var field in fields)
            {
                visualization.YAxes.Add(new MeasureColumnSpec()
                {
                    SummarizationField = new SummarizationValueField(field)
                });
            }
            return visualization;
        }

        public static T SetYAxes<T>(this T visualization, params SummarizationValueField[] fields)
            where T : IAxis
        {
            visualization.YAxes.Clear();
            foreach (var field in fields)
            {
                visualization.YAxes.Add(new MeasureColumnSpec()
                {
                    SummarizationField = field
                });
            }
            return visualization;
        }
    }
}
