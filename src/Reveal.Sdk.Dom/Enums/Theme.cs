using System.Runtime.Serialization;

namespace Reveal.Sdk.Dom
{
    public enum Theme
    {
        [EnumMember(Value = "rvDashboardAuroraTheme")]
        Aurora,
        [EnumMember(Value = "Circus")]
        Circus,
        [EnumMember(Value = "rvDashboardMountainTheme")]
        Mountain,
        [EnumMember(Value = "rvDashboardOceanTheme")]
        Ocean,
        [EnumMember(Value = "Rocky Mountain")]
        RockyMountain,
        [EnumMember(Value = "Tropical Island")]
        TropicalIsland
    }
}
