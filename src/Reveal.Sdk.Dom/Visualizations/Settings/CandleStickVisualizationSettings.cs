namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public sealed class CandleStickVisualizationSettings : FinancialVisualizationSettingsBase
    {
        public CandleStickVisualizationSettings()
        {
            ChartType = RdashChartType.Candlestick;
        }
    }
}
