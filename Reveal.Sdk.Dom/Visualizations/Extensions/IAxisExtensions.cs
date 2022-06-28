namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IAxisExtensions
    {
        public static T AddXAxis<T>(this T visualization, string xAxisField)
            where T : IAxis
        {
            visualization.AddXAxis(new SummarizationValueField(xAxisField));
            return visualization;
        }

        public static T AddXAxis<T>(this T visualization, SummarizationValueField xAxisField)
            where T : IAxis
        {
            visualization.XAxis.Add(new MeasureColumnSpec()
            {
                SummarizationField = xAxisField
            });
            return visualization;
        }

        public static T AddYAxis<T>(this T visualization, string yAxisField)
            where T : IAxis
        {
            visualization.AddYAxis(new SummarizationValueField(yAxisField));
            return visualization;
        }

        public static T AddYAxis<T>(this T visualization, SummarizationValueField yAxisField)
            where T : IAxis
        {
            visualization.YAxis.Add(new MeasureColumnSpec()
            {
                SummarizationField = yAxisField
            });
            return visualization;
        }
    }
}
