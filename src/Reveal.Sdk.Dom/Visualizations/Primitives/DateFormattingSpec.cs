using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class DateFormattingSpec : FormattingSpec
    {
        public string DateFormat { get; set; }

        public DateFormattingSpec()
        {
            SchemaTypeName = SchemaTypeNames.DateFormattingSpecType;
        }
    }
}
