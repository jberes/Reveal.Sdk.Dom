using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class GaugeVisualization : LinearGaugeVisualizationBase<GaugeVisualizationSettings>, IGaugeVisualization
    {
        internal GaugeVisualization() : this(null) { }

        public GaugeVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        public GaugeVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        //todo: mutliple classes use this, let's create a base class
        [JsonIgnore]
        public List<GaugeBand> Bands { get { return Settings.GaugeBands; } }
    }
}
