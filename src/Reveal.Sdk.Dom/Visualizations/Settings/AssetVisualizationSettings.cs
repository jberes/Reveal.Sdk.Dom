using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public sealed class AssetVisualizationSettings : VisualizationSettings
    {
        public AssetVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.AssetVisualizationSettingsType;
            VisualizationType = VisualizationTypes.IMAGE;
        }
    }
}
