namespace Reveal.Sdk.Dom.Visualizations
{
    public interface ISparklineVisualization : IDate, IValues, ICategories
    {
        int NumberOfPeriods { get; set; }

        bool ShowIndicator { get; set; }
    }
}
