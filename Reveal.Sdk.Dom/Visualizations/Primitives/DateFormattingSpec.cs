using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
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
