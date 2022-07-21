using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class DimensionColumn : ColumnBase
    {
        public DimensionColumn()
        {
            SchemaTypeName = SchemaTypeNames.DimensionColumnSpecType;
        }

        /// <summary>
        /// Gets or sets the <see cref="DataField"/>. Choose from the <see cref="DateDataField"/> or the <see cref="TextDataField"/>.
        /// </summary>
        [JsonProperty("SummarizationField")]
        public IDimensionDataField DataField { get; set; }

        [JsonProperty]
        internal XmlaDimensionElement XmlaElement { get; set; }
    }
}
