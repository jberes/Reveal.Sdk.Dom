using Reveal.Sdk.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.DashboardFactories
{
    internal class MongoDashboard : IDashboardCreator
    {
        public string Name => "Mongo Data Source";

        public RdashDocument CreateDashboard()
        {
            throw new NotImplementedException();
        }
    }
}
