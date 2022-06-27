using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class BulletGraphVisualization : LinearGaugeVisualizationBase<GaugeVisualizationSettings>, IGaugeVisualization, IBands
    {
        internal BulletGraphVisualization() : this(null) { }

        public BulletGraphVisualization(DataSourceItem dataSourceItem) : this(string.Empty, dataSourceItem) { }

        public BulletGraphVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem)
        {
            Settings.ViewType = GaugeViewType.BulletGraph;
        }

        //todo: mutliple classes use this, let's create a base class
        [JsonIgnore]
        public List<GaugeBand> Bands { get { return Settings.GaugeBands; } }
    }
}
