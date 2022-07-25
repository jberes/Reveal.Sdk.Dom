using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations
{
    internal sealed class DataProcessingOutputField
    {
        public string OutputColumnName { get; set; }
        public string ResultColumnName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public DataType DataType { get; set; }
        public string FeatureName { get; set; }
        public bool IsBoolean { get; set; }
        public string ReferenceColumn { get; set; }

        public DataProcessingOutputField()
        {
            DataType = DataType.String;
        }
    }
}
