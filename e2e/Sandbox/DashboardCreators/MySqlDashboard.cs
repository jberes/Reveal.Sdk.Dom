using Reveal.Sdk.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.DashboardFactories
{
    internal class MySqlDashboard : IDashboardCreator
    {
        public string Name => "MySql data source";

        public RdashDocument CreateDashboard()
        {
            throw new NotImplementedException();
        }
    }
}
