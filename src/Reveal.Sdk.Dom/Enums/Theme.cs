using System;
using System.Runtime.Serialization;

namespace Reveal.Sdk.Dom
{
    public enum Theme
    {
        [EnumMember(Value = "rvDashboardAuroraTheme")]
        Aurora,
        
        [EnumMember(Value = "rvDashboardMountainTheme")]
        Mountain,
        
        [EnumMember(Value = "rvDashboardOceanTheme")]
        Ocean,
        
        [Obsolete("This theme is no longer used. Please use Aurora, Mountain, or Ocean.")]
        [EnumMember(Value = "Circus")]
        Circus,

        [Obsolete("This theme is no longer used. Please use Aurora, Mountain, or Ocean.")]
        [EnumMember(Value = "Rocky Mountain")]
        RockyMountain,

        [Obsolete("This theme is no longer used. Please use Aurora, Mountain, or Ocean.")]
        [EnumMember(Value = "Tropical Island")]
        TropicalIsland
    }
}
