using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class VisualizationLinkConverter : TypeMapConverter<IVisualizationLink>
    {
        public VisualizationLinkConverter() : base("Type")
        {            
            TypeMap = new Dictionary<string, Type>()
            {
                { "OpenUrl", typeof(UrlLink) },
                { "OpenDashboard", typeof(DashboardLink) },
            };
        }
    }
}
