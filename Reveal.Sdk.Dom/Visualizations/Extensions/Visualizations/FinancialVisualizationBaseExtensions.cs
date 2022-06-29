using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class FinancialVisualizationBaseExtensions
    {
        public static T AddOpen<T>(this T visualization, string openField)
            where T : FinancialVisualizationBase<ChartVisualizationSettings>
        {
            visualization.AddOpen(new SummarizationValueField(openField));
            return visualization;
        }

        public static T AddOpen<T>(this T visualization, SummarizationValueField openField)
            where T : FinancialVisualizationBase<ChartVisualizationSettings>
        {
            visualization.Open.Add(new MeasureColumnSpec() { SummarizationField = openField });
            return visualization;
        }

        public static T AddHigh<T>(this T visualization, string highField)
            where T : FinancialVisualizationBase<ChartVisualizationSettings>
        {
            visualization.AddHigh(new SummarizationValueField(highField));
            return visualization;
        }

        public static T AddHigh<T>(this T visualization, SummarizationValueField highField)
            where T : FinancialVisualizationBase<ChartVisualizationSettings>
        {
            visualization.High.Add(new MeasureColumnSpec() { SummarizationField = highField });
            return visualization;
        }

        public static T AddLow<T>(this T visualization, string lowField)
            where T : FinancialVisualizationBase<ChartVisualizationSettings>
        {
            visualization.AddLow(new SummarizationValueField(lowField));
            return visualization;
        }

        public static T AddLow<T>(this T visualization, SummarizationValueField lowField)
            where T : FinancialVisualizationBase<ChartVisualizationSettings>
        {
            visualization.Low.Add(new MeasureColumnSpec() { SummarizationField = lowField });
            return visualization;
        }

        public static T AddClose<T>(this T visualization, string closeField)
            where T : FinancialVisualizationBase<ChartVisualizationSettings>
        {
            visualization.AddClose(new SummarizationValueField(closeField));
            return visualization;
        }

        public static T AddClose<T>(this T visualization, SummarizationValueField closeField)
            where T : FinancialVisualizationBase<ChartVisualizationSettings>
        {
            visualization.Close.Add(new MeasureColumnSpec() { SummarizationField = closeField });
            return visualization;
        }
    }
}
