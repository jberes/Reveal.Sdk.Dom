using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Core.Serialization;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Variables;

namespace Reveal.Sdk.Dom
{
    public class DashboardDocument
    {
        public DashboardDocument() : this("New Dashboard") { }

        public DashboardDocument(string title)
        {
            Title = title;
        }

        /// <summary>
        /// Gets or sets the title of the dashboard.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the desctiption of the dashboard
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the theme the dashboard will apply to all visualizations.
        /// </summary>
        [JsonProperty("ThemeName")]
        public string Theme { get; set; }

        /// <summary>
        /// Gets the name of the API that created the dashboard.
        /// </summary>
        [JsonProperty]
        public string CreatedWith { get; private set; } = GlobalConstants.DashboardDocument.CreatedWith;

        /// <summary>
        /// Gets the name of the API that last saved the dashboard.
        /// </summary>
        [JsonProperty]
        public string SavedWith { get; internal set; } = string.Empty;

        /// <summary>
        /// Gets a value which represents the format of the dashboard.
        /// </summary>
        [JsonProperty]
        public int FormatVersion { get; private set; }

        /// <summary>
        /// Gets or sets whether the RevealView displaying the dashboard will automatically layout visualizations, or use an absolute layout controlled by each visualization's ColumnSpan and RowSpan properties. True by default.
        /// </summary>
        public bool UseAutoLayout { get; set; } = true;

        /// <summary>
        /// TODO:
        /// </summary>
        public int? AutoRefreshInterval { get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Gets the collection of data sources available for creating visualizations.
        /// </summary>
        [JsonProperty]
        public List<DataSource> DataSources { get; internal set; } = new List<DataSource>();

        /// <summary>
        /// Gets the collection of dashboard filters that can bound to any visualization using the visualization's FilterBindings property.
        /// </summary>
        [JsonProperty("GlobalFilters")]
        public List<DashboardFilter> Filters { get; internal set; } = new List<DashboardFilter>();

        /// <summary>
        /// TODO: implement
        /// </summary>
        [JsonProperty]
        internal List<GlobalVariable> GlobalVariables { get; set; } = new List<GlobalVariable>();

        /// <summary>
        /// Gets the collection of visualizations that are displayed in the dashboard.
        /// </summary>
        [JsonProperty("Widgets")]
        public List<IVisualization> Visualizations { get; internal set; } = new List<IVisualization>();

        /// <summary>
        /// Creates a DashboardDocument from a dashboard file (.rdash).
        /// </summary>
        /// <param name="filePath">The file path to the dashboard file (.rdash).</param>
        /// <returns>The DashbardDocument representing the contents of the loaded .rdash file</returns>
        public static DashboardDocument Load(string filePath)
        {
            return RdashSerializer.Load(filePath);
        }

        /// <summary>
        /// Saves the DashboardDocument as an RDASH file.
        /// </summary>
        /// <param name="filePath">The file path to save the Dashboard (must include the .rdash extensions)</param>
        public void Save(string filePath)
        {
            RdashSerializer.Save(this, filePath);            
        }

        /// <summary>
        /// Converts the DashboardDocument to a JSON string.
        /// </summary>
        /// <returns>A JSON string representing the DashboardDocument</returns>
        public string ToJsonString()
        {
            return RdashSerializer.Serialize(this);
        }
    }
}
