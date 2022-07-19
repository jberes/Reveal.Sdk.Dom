using System.Runtime.Serialization;

namespace Reveal.Sdk.Dom.Visualizations
{
    public enum MapLabelStyle
    {
        /// <summary>
        /// Display labels as an abbreviated geographical name.
        /// </summary>
        [EnumMember(Value = "ABBREVIATION")]
        LocationAbbreviation,
        /// <summary>
        /// Display labels as values.
        /// </summary>
        [EnumMember(Value = "VALUES")]
        Values
    }
}
