namespace Reveal.Sdk.Dom.Visualizations.Builder
{
    public interface IVisualizationBuilderBase<T>
        where T : Visualization
    {
        T Build();
    }
}
