using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Core;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class FixedLine : SchemaType, IFixedLine
    {
        /// <summary>
        /// Internal integer color representation used for serialization.
        /// </summary>
        [JsonProperty("Color")]
        private int? colorInt;

        /// <summary>
        /// Gets or sets the color of the fixed line.
        ///
        /// Accepts:
        /// - A hex string: #RRGGBB (opaque) or #RRGGBBAA (with alpha)
        /// - An RGB/RGBA string: rgb(r, g, b) or rgba(r, g, b, a)
        ///
        /// Returns:
        /// - A hex color string:
        ///   - #RRGGBB if the color is fully opaque
        ///   - #RRGGBBAA if an alpha value was specified
        /// </summary>
        [JsonIgnore]
        public string Color
        {
            get => colorInt is null ? null : ColorUtility.IntToHexColorString(colorInt.Value);
            set => colorInt = string.IsNullOrWhiteSpace(value) ? (int?)null : ColorUtility.FromColorString(value);
        }

        /// <summary>
        /// Gets or sets the formatting of the fixed line.
        /// </summary>
        public NumberFormatting Formatting { get; set; } = new NumberFormatting();

        /// <summary>
        /// The identifier of the fixed line. This is only used internally in the RevealView to prevent multiple fixed lines with the same identifier.
        /// </summary>
        [JsonProperty]
        protected string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the line style of the fixed line.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LineStyle LineStyle { get; set; } = LineStyle.Solid;

        /// <summary>
        /// The type of the fixed line. This is only used internally in the RevealView to determine the type of the fixed line.
        /// </summary>
        [JsonProperty("LineType")]
        [JsonConverter(typeof(StringEnumConverter))]
        protected FixedLineType FixedLineType { get; set; } = FixedLineType.None;

        /// <summary>
        /// Gets or sets the thickness of the fixed line.
        /// </summary>
        public double Thickness { get; set; } = 2;

        /// <summary>
        /// Gets or sets the title of the fixed line.
        /// </summary>
        public string Title { get; set; }
    }
}
