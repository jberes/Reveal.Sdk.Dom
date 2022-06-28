using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class ChoroplethMapVisualizationSettings : GeoMapBaseVisualizationSettings
    {
        public string ColorizationStyle { get; set; }
        public bool IncludeAdjacentShapes { get; set; } = true;
        public string LabelVisibility { get; set; } = "VALUES ONLY"; //todo: enum or constant here?
        public string LabelStyle { get; set; } = "ABBREVIATION"; //todo: enum or constant here?
        public ChoroplethMapColorType ColorBasedOn { get; set; } = ChoroplethMapColorType.Highest;
        public string DataLocale { get; set; }
        public List<string> Regions { get; set; } = new List<string>();

        public ChoroplethMapVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.ChoroplethMapVisualizationSettingsType;
        }
    }
}
