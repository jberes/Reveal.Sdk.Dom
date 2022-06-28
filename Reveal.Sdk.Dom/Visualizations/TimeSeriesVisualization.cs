using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class TimeSeriesVisualization : Visualization<ChartVisualizationSettings>
    {
        internal TimeSeriesVisualization() : this(null) { }
        public TimeSeriesVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
        public TimeSeriesVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        //todo: implement

        [JsonProperty(Order = 7)]
        TimeSeriesVisualizationDataSpec VisualizationDataSpec { get; set; } = new TimeSeriesVisualizationDataSpec();
    }
}
