using Reveal.Sdk.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.DashboardFactories
{
    internal class GoogleDriveDashboard : IDashboardCreator
    {
        public string Name => "Google Drive Data Source";

        public RdashDocument CreateDashboard()
        {
            throw new NotImplementedException();
        }
    }
}
