using System.Runtime.Serialization;

namespace Reveal.Sdk.Dom.Visualizations
{
    public enum MapLabelVisibility
    {
        /// <summary>
        /// Display labels on all regions.
        /// </summary>
        [EnumMember(Value = "ALL")]
        All,
        /// <summary>
        /// Display labels only on regions that have values.
        /// </summary>
        [EnumMember(Value = "HAS VALUES")]
        HasValues,
        /// <summary>
        /// Do not display labels.
        /// </summary>
        [EnumMember(Value = "NONE")]
        None
    }
}
