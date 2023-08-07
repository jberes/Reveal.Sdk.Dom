using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface ITabularVisualization : IVisualization, IFilterBindings, IDataDefinitionProvider<TabularDataDefinition>
    {
        List<VisualizationFilter> Filters { get; }

        void UpdateDataSourceItem(DataSourceItem dataSourceItem);

        DataSourceItem GetDataSourceItem();
    }
}