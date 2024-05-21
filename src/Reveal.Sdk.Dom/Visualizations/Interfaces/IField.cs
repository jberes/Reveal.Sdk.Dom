using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Serialization.Converters;

namespace Reveal.Sdk.Dom.Visualizations
{
    [JsonConverter(typeof(FieldConverter))]
    public interface IField
    {
        /// <summary>
        /// Get or sets the expression to use if this field is a calculated field.
        /// </summary>
        string Expression { get; set; }

        /// <summary>
        /// Gets or sets the field name. It must match the name as it exists in the data source.
        /// </summary>
        string FieldName { get; set; }

        /// <summary>
        /// Gets or sets the field label. This is the friendly name and will be displayed in the UI.
        /// </summary>
        string FieldLabel { get; set; }

        /// <summary>
        /// Gets or sets whether this is a calucated field.
        /// </summary>
        bool IsCalculated { get; set; }

        /// <summary>
        /// Gets or sets the table alias for this field.
        /// </summary>
        string TableAlias { get; set; }
    }
}