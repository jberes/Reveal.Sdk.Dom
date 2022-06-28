using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class FinancialVisualizationBase<TSettings> : Visualization<TSettings>
        where TSettings : ChartVisualizationSettings, new()
    {
        protected FinancialVisualizationBase(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
        protected FinancialVisualizationBase(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }

        //todo: implement

        [JsonProperty(Order = 7)]
        FinancialVisualizationDataSpec VisualizationDataSpec { get; set; } = new FinancialVisualizationDataSpec();
    }
}
