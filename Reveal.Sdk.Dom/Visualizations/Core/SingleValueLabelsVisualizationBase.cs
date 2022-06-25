using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class SingleValueLabelsVisualizationBase<TSettings> : Visualization<TSettings, SingleValueLabelsVisualizationDataSpec>
        where TSettings : VisualizationSettings, new()
    {
        protected SingleValueLabelsVisualizationBase(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        [JsonIgnore]
        public List<DimensionColumnSpec> Labels { get { return GetVisualizationDataSpec().Rows; } }

        [JsonIgnore]
        public List<MeasureColumnSpec> Values { get { return GetVisualizationDataSpec().Value; } }
    }
}