namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IFinanceExtensions
    {
        public static T AddOpen<T>(this T visualization, string field)
            where T : IFinance
        {
            return visualization.AddOpen(new SummarizationValueField(field));
        }

        public static T AddOpen<T>(this T visualization, SummarizationValueField field)
            where T : IFinance
        {
            visualization.Open.Add(new MeasureColumnSpec()
            {
                SummarizationField = field
            });
            return visualization;
        }

        public static T AddHigh<T>(this T visualization, string field)
            where T : IFinance
        {
            return visualization.AddHigh(new SummarizationValueField(field));
        }
        
        public static T AddHigh<T>(this T visualization, SummarizationValueField field)
            where T : IFinance
        {
            visualization.High.Add(new MeasureColumnSpec()
            {
                SummarizationField = field
            });
            return visualization;
        }

        public static T AddLow<T>(this T visualization, string field)
            where T : IFinance
        {
            return visualization.AddLow(new SummarizationValueField(field));
        }

        public static T AddLow<T>(this T visualization, SummarizationValueField field)
            where T : IFinance
        {
            visualization.Low.Add(new MeasureColumnSpec()
            {
                SummarizationField = field
            });
            return visualization;
        }

        public static T AddClose<T>(this T visualization, string field)
            where T : IFinance
        {
            return visualization.AddClose(new SummarizationValueField(field));
        }

        public static T AddClose<T>(this T visualization, SummarizationValueField field)
            where T : IFinance
        {
            visualization.Close.Add(new MeasureColumnSpec()
            {
                SummarizationField = field
            });
            return visualization;
        }
    }
}
