using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class BulletGraphVisualization : LinearGaugeVisualizationBase<BulletGraphVisualizationSettings>, ITargets
    {
        internal BulletGraphVisualization() : this(null) { }
        public BulletGraphVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }
        public BulletGraphVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        [JsonIgnore]
        public List<MeasureColumn> Targets { get { return VisualizationDataSpec.Target; } }
    }
}
