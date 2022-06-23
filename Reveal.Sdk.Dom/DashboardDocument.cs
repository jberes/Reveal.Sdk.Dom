using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Serialization;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Variables;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Reveal.Sdk.Dom.Serialization.Attributes;

namespace Reveal.Sdk.Dom
{
    public class DashboardDocument
	{
		public string Title { get; set; }
		public string Description { get; set; }

        [JsonPropertyName("ThemeName")]
        [JsonStringEnumSpacesConverter]
		public Theme Theme { get; set; }

		[JsonInclude]
		public string CreatedWith { get; internal set; } = "Reveal.Sdk.DOM";

		[JsonInclude]
		public string SavedWith { get; internal set; }

		[JsonInclude]
		public int FormatVersion { get; internal set; }

		public bool UseAutoLayout { get; set; } = true;
		public int? AutoRefreshInterval { get; set; }
		public string PasswordHash { get; set; }
		public string Tags { get; set; }

        [JsonInclude]
		public List<DataSource> DataSources { get; internal set; } = new List<DataSource>();

		[JsonInclude]
		[JsonPropertyName("GlobalFilters")]
		public List<DashboardFilter> Filters { get; internal set; } = new List<DashboardFilter>();

		[JsonInclude]
		public List<GlobalVariable> GlobalVariables { get; internal set; } = new List<GlobalVariable>();

		[JsonInclude]
		[JsonPropertyName("Widgets")]
		public List<Visualization> Visualizations { get; internal set; } = new List<Visualization>();

		public DashboardDocument() : this("New Dashboard") { }

		public DashboardDocument(string title) 
		{
			Title = title;
		}

		public static DashboardDocument Load(string filePath)
		{
			return RdashSerializer.Deserialize(filePath);
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
