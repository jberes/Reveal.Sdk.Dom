using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System;

namespace Reveal.Sdk.Dom.Visualizations.Builder
{
    public class ChartBuilder<T, TSettings> : IChartBuilder<T, TSettings>
        where T : Visualization
        where TSettings : VisualizationSettings
    {
        protected T Visualization { get; set; }

        IVisualizationDataSpec<CategoryVisualizationDataSpec> CategoryChart
        {
            get { return (IVisualizationDataSpec<CategoryVisualizationDataSpec>)Visualization; }
        }

        public ChartBuilder(string title, DataSourceItem dataSourceItem)
        {
            Visualization = (T)Activator.CreateInstance(typeof(T), args: dataSourceItem);
            Visualization.Title = title;
        }

        public IChartBuilder<T,TSettings> SetPosition(int rowSpan, int columnSpan)
        {
            Visualization.RowSpan = rowSpan;
            Visualization.ColumnSpan = columnSpan;
            return this;
        }

        public IChartBuilder<T,TSettings> AddLabel(string labelField)
        {
            var field = new SummarizationRegularField(labelField);
            AddLabel(field);
            return this;
        }

        public IChartBuilder<T,TSettings> AddLabel(SummarizationDimensionField labelField)
        {
            CategoryChart.VisualizationDataSpec.Rows.Add(new DimensionColumnSpec()
            {
                SummarizationField = labelField
            });
            return this;
        }

        public IChartBuilder<T,TSettings> AddValue(string valueFied)
        {
            var value = new SummarizationValueField(valueFied);
            AddValue(value);
            return this;
        }

        public IChartBuilder<T,TSettings> AddValue(SummarizationValueField valueFied)
        {
            CategoryChart.VisualizationDataSpec.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = valueFied
            });
            return this;
        }

        public IChartBuilder<T, TSettings> AddValues(params string[] valueFieds)
        {
            foreach(var valueFied in valueFieds)
            {
                var value = new SummarizationValueField(valueFied);
                AddValue(value);
            }            
            return this;
        }

        public IChartBuilder<T,TSettings> AddFilter(string filter)
        {
            Visualization.Filters.Add(new VisualizationFilter(filter));
            return this;
        }

        public IChartBuilder<T,TSettings> AddFilters(params string[] filters)
        {
            foreach (var filter in filters)
            {
                Visualization.Filters.Add(new VisualizationFilter(filter));
            }
            return this;
        }

        public IChartBuilder<T, TSettings> AddFilterBinding(Binding filterBinding)
        {
            Visualization.FilterBindings.Add(filterBinding);
            return this;
        }

        public IChartBuilder<T, TSettings> AddFilterBindings(params Binding[] filterBindings)
        {
            Visualization.FilterBindings.AddRange(filterBindings);
            return this;
        }

        public IChartBuilder<T, TSettings> ConfigureSettings(Action<TSettings> setting)
        {
            var vizSettings = (IVisualizationSettings<TSettings>)Visualization;
            setting.Invoke(vizSettings.Settings);
            return this;
        }

        public T Build()
        {
            return Visualization;
        }
    }
}
