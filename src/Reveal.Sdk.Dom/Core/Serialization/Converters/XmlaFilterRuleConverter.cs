using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class XmlaFilterRuleConverter : TypeMapConverter<XmlaFilterRule>
    {
        public XmlaFilterRuleConverter()
        {
            TypeMap = new Dictionary<string, Type>()
            {
                { SchemaTypeNames.XmlaNumberFilterRuleType, typeof(XmlaNumberFilterRule) },
                { SchemaTypeNames.XmlaStringFilterRuleType, typeof(XmlaStringFilterRule) },
            };
        }
    }
}
