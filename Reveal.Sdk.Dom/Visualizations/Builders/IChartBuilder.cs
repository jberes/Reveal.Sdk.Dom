using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations.Builder
{
    public interface IChartBuilder<T, TSettings> : IVisualizationBuilderBase<T>
        where T : Visualization
        where TSettings : VisualizationSettings
    {
        IChartBuilder<T,TSettings> AddLabel(string labelField);
        IChartBuilder<T,TSettings> AddLabel(SummarizationDimensionField labelField);
        IChartBuilder<T,TSettings> AddValue(string valueFied);
        IChartBuilder<T,TSettings> AddValue(SummarizationValueField valueFied);
        IChartBuilder<T,TSettings> AddValues(params string[] valueFieds);
        IChartBuilder<T,TSettings> AddFilter(string filter);
        IChartBuilder<T,TSettings> AddFilters(params string[] filters);
        IChartBuilder<T,TSettings> AddFilterBinding(Binding filterBinding);
        IChartBuilder<T,TSettings> AddFilterBindings(params Binding[] filterBindings);
        IChartBuilder<T,TSettings> ConfigureSettings(Action<TSettings> settings);
        IChartBuilder<T,TSettings> SetPosition(int rowSpan, int columnSpan);
    }
}
