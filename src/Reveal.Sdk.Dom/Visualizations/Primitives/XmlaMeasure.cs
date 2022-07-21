using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations
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
        public FormattingBase Formatting { get; set; }
        public ConditionalFormatting ConditionalFormatting { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public SortingType Sorting { get; set; }

        public XmlaMeasure()
        {
            Sorting = SortingType.None;
        }
    }
}