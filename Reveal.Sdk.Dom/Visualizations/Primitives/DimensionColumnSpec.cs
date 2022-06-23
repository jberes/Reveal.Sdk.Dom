using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Serialization.Converters;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class DimensionColumnSpec : ColumnSpec
    {
        [JsonConverter(typeof(SummarizationFieldConverter))]
        public SummarizationDimensionField SummarizationField { get; set; }
        public XmlaDimensionElement XmlaElement { get; set; }

        public DimensionColumnSpec()
        {
            SchemaTypeName = SchemaTypeNames.DimensionColumnSpecType;
        }
    }
}
