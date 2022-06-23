using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class DateTimeFieldSettings : FieldSettings
    {
        public int DateFiscalYearStartMonth { get; set; }
        public bool DisplayInLocalTimeZone { get; set; }

        public DateTimeFieldSettings()
        {
            SchemaTypeName = SchemaTypeNames.DateTimeFieldSettingsType;
        }
    }
}
