using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class LinearGaugeVisualization : LinearGaugeVisualizationBase<GaugeVisualizationSettings>, IGaugeVisualization
    {
        internal LinearGaugeVisualization() : this(null) { }

        public LinearGaugeVisualization(DataSourceItem dataSourceItem) : this(string.Empty, dataSourceItem) { }

        public LinearGaugeVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) 
        {
            Settings.ViewType = GaugeViewType.Linear;
        }

        //todo: mutliple classes use this, let's create a base class
        [JsonIgnore]
        public List<GaugeBand> Bands { get { return Settings.GaugeBands; } }
    }
}
