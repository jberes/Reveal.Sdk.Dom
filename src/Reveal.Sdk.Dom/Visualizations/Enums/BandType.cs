using System.Runtime.Serialization;

namespace Reveal.Sdk.Dom.Visualizations
{
    public enum ValueComparisonType
	{
		Percentage,
        [EnumMember(Value = "NumberValue")]
        Number
	}
}
