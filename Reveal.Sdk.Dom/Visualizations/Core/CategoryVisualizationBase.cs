using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Serialization.Converters;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class CategoryVisualizationBase<TSettings> : Visualization<TSettings>, IVisualizationDataSpec<CategoryVisualizationDataSpec>
        where TSettings : VisualizationSettings, new()
    {
        protected CategoryVisualizationBase(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        [JsonIgnore]
        public List<DimensionColumnSpec> Labels { get { return VisualizationDataSpec.Rows; } }

        [JsonIgnore]
        public List<MeasureColumnSpec> Values { get { return VisualizationDataSpec.Values; } }

        [JsonIgnore]
        public DimensionColumnSpec Category
        {
            get { return VisualizationDataSpec.Category; }
            set { VisualizationDataSpec.Category = value; }
        }

        [JsonProperty(Order = 7)]
        CategoryVisualizationDataSpec VisualizationDataSpec { get; set; } = new CategoryVisualizationDataSpec();

        [JsonIgnore]
        CategoryVisualizationDataSpec IVisualizationDataSpec<CategoryVisualizationDataSpec>.VisualizationDataSpec { get { return VisualizationDataSpec; } } 
    }
}