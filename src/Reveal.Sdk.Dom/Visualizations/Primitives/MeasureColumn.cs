using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class MeasureColumn : ColumnBase
    {
        public MeasureColumn()
        {
            SchemaTypeName = SchemaTypeNames.MeasureColumnSpecType;
        }

        /// <summary>
        /// Gets or sets the <see cref="DataField"/>.
        /// </summary>
        [JsonProperty("SummarizationField")]
        public NumberDataField DataField { get; set; }

        [JsonProperty]
        internal XmlaMeasure XmlaMeasure { get; set; }
    }
}