using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class CategoryVisualizationBase<TSettings> : Visualization<TSettings, CategoryVisualizationDataSpec>
        where TSettings : VisualizationSettings, new()
    {
        protected CategoryVisualizationBase(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        [JsonIgnore]
        public List<DimensionColumnSpec> Labels { get { return GetVisualizationDataSpec().Rows; } }

        [JsonIgnore]
        public List<MeasureColumnSpec> Values { get { return GetVisualizationDataSpec().Values; } }

        [JsonIgnore]
        public DimensionColumnSpec Category
        {
            get { return GetVisualizationDataSpec().Category; }
            set { GetVisualizationDataSpec().Category = value; }
        }
    }
}