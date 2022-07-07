namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IAxisExtensions
    {
        public static T AddXAxis<T>(this T visualization, string field)
            where T : IAxis
        {
            return visualization.AddXAxis(new SummarizationValueField(field));
        }

        public static T AddXAxis<T>(this T visualization, SummarizationValueField field)
            where T : IAxis
        {
            visualization.XAxis.Add(new MeasureColumnSpec()
            {
                SummarizationField = field
            });
            return visualization;
        }

        public static T AddYAxis<T>(this T visualization, string field)
            where T : IAxis
        {
            return visualization.AddYAxis(new SummarizationValueField(field));
        }

        public static T AddYAxis<T>(this T visualization, SummarizationValueField field)
            where T : IAxis
        {
            visualization.YAxis.Add(new MeasureColumnSpec()
            {
                SummarizationField = field
            });
            return visualization;
        }
    }
}
