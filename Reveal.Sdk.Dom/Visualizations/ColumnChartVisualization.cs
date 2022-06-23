using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class ColumnChartVisualization : Visualization<ColumnChartVisualizationSettings, CategoryVisualizationDataSpec>
    {
        internal ColumnChartVisualization() : this(null) { }

        public ColumnChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
