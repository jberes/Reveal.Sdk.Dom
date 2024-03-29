namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public sealed class TimeSeriesVisualizationSettings : CategoryChartVisualizationSettings
    {
        public TimeSeriesVisualizationSettings()
        {
            ChartType = RdashChartType.TimeSeries;
        }
    }
}
