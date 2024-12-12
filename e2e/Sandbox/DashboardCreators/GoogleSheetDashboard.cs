using Reveal.Sdk.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.DashboardFactories
{
    internal class GoogleSheetDashboard : IDashboardCreator
    {
        public string Name => "Google Sheet Data Source";

        public RdashDocument CreateDashboard()
        {
            throw new NotImplementedException();
        }
    }
}
