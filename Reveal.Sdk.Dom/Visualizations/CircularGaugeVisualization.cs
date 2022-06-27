using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class CircularGaugeVisualization : SingleGaugeVisualizationBase<GaugeVisualizationSettings>
    {
        internal CircularGaugeVisualization() : this(null) { }

        public CircularGaugeVisualization(DataSourceItem dataSourceItem) : this(string.Empty, dataSourceItem) { }

        public CircularGaugeVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem)
        {
            Settings.ViewType = GaugeViewType.Circular;
        }

        //todo: mutliple classes use this, let's create a base class
        [JsonIgnore]
        public List<GaugeBand> Bands { get { return Settings.GaugeBands; } }
    }
}
