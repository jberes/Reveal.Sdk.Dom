using Reveal.Sdk.Dom.Filters;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations
{
    internal sealed class XmlaDimensionElement
    {
        public string UniqueName { get; set; }
        public string Caption { get; set; }
        public string UserCaption { get; set; }
        public string DimensionUniqueName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public XmlaDimensionType DimensionType { get; set; }
        public List<string> DrillDownElements { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public SortingType Sorting { get; set; }
        public bool FieldSortingByLabel { get; set; }
        public XmlaFilter XmlaFilter { get; set; }
        public int FullyExpandedLevels { get; set; }
        public List<string> ExpandedItems { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public DateAggregationType DateAggregationType { get; set; }
        public int DateFiscalYearStartMonth { get; set; }
        public List<XmlaMember> DrillDownMembers { get; set; }

        public XmlaDimensionElement()
        {
            DrillDownElements = new List<string>();
            ExpandedItems = new List<string>();
            DrillDownMembers = new List<XmlaMember>();
            DimensionType = XmlaDimensionType.Regular;
            Sorting = SortingType.None;
            DateAggregationType = DateAggregationType.Year;
        }
    }
}
