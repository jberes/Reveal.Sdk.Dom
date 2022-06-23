using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class XmlaMeasure
    {
        public bool IsHidden { get; set; }
        public string UniqueName { get; set; }
        public string Caption { get; set; }
        public string DisplayFolder { get; set; }
        public string MeasureGroupName { get; set; }
        public string UserCaption { get; set; }
        public bool IsCalculated { get; set; }
        public string Expression { get; set; }
        public FormattingSpec Formatting { get; set; }
        public ConditionalFormattingSpec ConditionalFormatting { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SortingType Sorting { get; set; }

        public XmlaMeasure()
        {
            Sorting = SortingType.None;
        }
    }
}