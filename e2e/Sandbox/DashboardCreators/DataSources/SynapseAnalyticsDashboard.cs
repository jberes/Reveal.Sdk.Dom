using Reveal.Sdk.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.DashboardFactories
{
    internal class SynapseAnalyticsDashboard : IDashboardCreator
    {
        public string Name => "MS Synapse Analytics DataSource";

        public RdashDocument CreateDashboard()
        {
            throw new NotImplementedException();
        }
    }
}
