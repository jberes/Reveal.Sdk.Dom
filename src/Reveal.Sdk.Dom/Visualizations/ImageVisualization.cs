using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The image visualization is used for displaying images, PDFs, or web content.
    /// TODO: Missing Settings class for Image Visualization
    /// </summary>
    public sealed class ImageVisualization : Visualization<AssetVisualizationSettings>
    {
        internal ImageVisualization() : this(null) { }

        /// <summary>
        /// Creates a image visualization from the supplied <see cref="DataSourceItem"/>.
        /// </summary>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public ImageVisualization(DataSourceItem dataSourceItem) : this(null, dataSourceItem) { }

        /// <summary>
        /// Creates a image visualization from the supplied <see cref="DataSourceItem"/> and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        /// <param name="dataSourceItem">The data soure item used to represent a dataset.</param>
        public ImageVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { ChartType = ChartType.Image; }

        [JsonIgnore]
        public TabularColumn Url 
        { 
            get { return VisualizationDataSpec.UrlColumn; } 
            set { VisualizationDataSpec.UrlColumn = value; }
        }

        [JsonProperty(Order = 7)]
        AssetVisualizationDataSpec VisualizationDataSpec { get; set; } = new AssetVisualizationDataSpec();
    }
}
