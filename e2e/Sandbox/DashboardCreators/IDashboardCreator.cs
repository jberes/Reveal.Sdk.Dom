using Reveal.Sdk.Dom;

namespace Sandbox.DashboardFactories
{
    interface IDashboardCreator
    {
        string Name { get; }
        RdashDocument CreateDashboard();
    }
}
