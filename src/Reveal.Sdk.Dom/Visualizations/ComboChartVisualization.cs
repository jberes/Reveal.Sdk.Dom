using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The combo chart visualization is used to combine two different category charts into one visualization. This visualization type only supports adding these chart types; column, stacked column, area, line, step area, step line, and spline area.
    /// </summary>
    //public sealed class ComboChartVisualization : TabularVisualizationBase<ComboChartVisualizationSettings>, ILabels
    public sealed class ComboChartVisualization : Visualization<ComboChartVisualizationSettings>, ILabels
    {
        internal ComboChartVisualization() : this(null) { }

        /// <summary>
        /// Creates a combo chart visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public ComboChartVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a combo chart visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public ComboChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { ChartType = ChartType.Combo; }

        [JsonProperty(Order = 7)]
        CompositeChartVisualizationDataSpec VisualizationDataSpec { get; set; } = new CompositeChartVisualizationDataSpec();

        [JsonIgnore]
        public List<MeasureColumn> Chart1 { get { return VisualizationDataSpec.Chart1; } }

        [JsonIgnore]
        public List<MeasureColumn> Chart2 { get { return VisualizationDataSpec.Chart2; } }

        [JsonIgnore]
        public List<DimensionColumn> Labels { get { return VisualizationDataSpec.Rows; } }
    }
}
