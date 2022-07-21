using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class DateFormatting : FormattingBase
    {
        internal DateFormatting() : this(null) { }
        public DateFormatting(string dateFormat)
        {
            SchemaTypeName = SchemaTypeNames.DateFormattingSpecType;
            DateFormat = dateFormat;
        }

        /// <summary>
        /// Gets or sets the date format. For example: dd-MMM-yyyy
        /// </summary>
        public string DateFormat { get; set; }
    }
}
