using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The bullet graph visualization allows for a linear and concise view of measures compared against a scale. A bullet graph is one of the most effective and efficient ways to present progress towards goals, good/better/best ranges, or compare multiple measurements in as little horizontal or vertical space as possible.
    /// </summary>
    public sealed class BulletGraphVisualization : LinearGaugeVisualizationBase<BulletGraphVisualizationSettings>, ITargets
    {
        internal BulletGraphVisualization() : this(null) { }

        /// <summary>
        /// Creates a bullet graph visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public BulletGraphVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a bullet graph visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public BulletGraphVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { ChartType = ChartType.BulletGraph; }

        [JsonIgnore]
        public List<MeasureColumn> Targets { get { return VisualizationDataSpec.Target; } }
    }
}
