using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Variables;
using System;

namespace Reveal.Sdk.Dom.Serialization.Converters
{
    internal class BindingTargetConverter : TypeMapConverter<BindingTarget>
    {
        public BindingTargetConverter()
        {
            TypeMap = new System.Collections.Generic.Dictionary<string, Type>()
            {
                { SchemaTypeNames.DataBasedGlobalFilterBindingTargetType, typeof(DashboardDataFilterBindingTarget) },
                { SchemaTypeNames.DateGlobalFilterBindingTargetType, typeof(DashboardDateFilterBindingTarget) },
                { SchemaTypeNames.GlobalVariableBindingTargetType, typeof(GlobalVariableBindingTarget) }
            };
        }
    }
}
