namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    //todo: not sure this is the right base class for this chart type
    //the json schema needs the ChartVisualizationSettingsType, but this base class
    //has too many properties that are not used by this chart type
    public class OHLCVisualizationSettings : ChartVisualizationSettings
    {
        public OHLCVisualizationSettings()
        {
            ChartType = ChartType.OHLC;
        }
    }
}
