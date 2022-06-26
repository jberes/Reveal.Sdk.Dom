using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class Visualization<T> : Visualization
        where T : VisualizationSettings, new()
    {
        protected Visualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        protected Visualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        [JsonProperty("VisualizationSettings", Order = 5)]
        public T Settings { get; internal set; } = new T();
    }
}
