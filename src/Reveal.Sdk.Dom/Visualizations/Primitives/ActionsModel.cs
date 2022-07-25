using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    //todo: implement, rename classes, and move classes to files
    internal sealed class ActionsModel
    {
        public DashboardActionTriggerType Trigger { get; set; } = DashboardActionTriggerType.SelectRow;
        public List<Action> Actions { get; set; }
    }

    internal enum DashboardActionTriggerType
    {
        SelectRow,
        Maximize
    }

    internal sealed class Action
    {
        public DashboardActionTargetType Type { get; set; } = DashboardActionTargetType.OpenDashboard;
        public string Title { get; set; }
        public string Url { get; set; }
        public List<ActionParameter> Parameters { get; set; } = new List<ActionParameter>();     
    }

    internal enum DashboardActionTargetType
    {
        OpenDashboard,
        OpenUrl
    }

    internal sealed class ActionParameter
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public DashboardActionParameterSourceType Type { get; set; } = DashboardActionParameterSourceType.Column;
        public string Value { get; set; }
    }

    internal enum DashboardActionParameterSourceType
    {
        Column,
        Literal,
        GlobalFilter
    }
}
