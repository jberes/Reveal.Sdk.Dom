using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public sealed class TreeMapVisualizationSettings : VisualizationSettings
    {
		public TreeMapVisualizationSettings()
		{
			SchemaTypeName = SchemaTypeNames.TreeMapVisualizationSettingsType;
			VisualizationType = VisualizationTypes.TREE_MAP;
		}

		/// <summary>
		/// Gets or sets the color index for the visualization's starting color. A zero-based index is used to set colors instead of a color name.
		/// For example, an index of 5 would be the 6th color in the color scheme regardless of the theme colors being used.
		/// </summary>
		[JsonProperty("BrushOffsetIndex")]
		public int? StartColorIndex { get; set; }

		/// <summary>
		/// Gets or sets whether to show labels that display information about the categories and values.
		/// </summary>
		public bool ShowValues { get; set; } = true;
	}
}
