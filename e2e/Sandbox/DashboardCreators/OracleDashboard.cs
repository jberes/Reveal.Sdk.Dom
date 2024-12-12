using Reveal.Sdk.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.DashboardFactories
{
    internal class OracleDashboard : IDashboardCreator
    {
        public string Name => "Oracle Data Source";

        public RdashDocument CreateDashboard()
        {
            throw new NotImplementedException();
        }
    }
}
