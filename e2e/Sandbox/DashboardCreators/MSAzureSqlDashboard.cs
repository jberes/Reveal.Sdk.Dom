using Reveal.Sdk.Dom;
using Sandbox.DashboardFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.DashboardFactories
{
    internal class MSAzureSqlDashboard : IDashboardCreator
    {
        public string Name => "MS Azure Sql Data Source";

        public RdashDocument CreateDashboard()
        {
            throw new NotImplementedException();
        }
    }
}
