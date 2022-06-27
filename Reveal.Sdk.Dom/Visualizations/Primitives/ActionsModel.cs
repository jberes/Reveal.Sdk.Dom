using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class ActionsModel
    {
        public DashboardActionTriggerType Trigger { get; set; } = DashboardActionTriggerType.SelectRow;
        public List<Action> Actions { get; set; }
    }

    public enum DashboardActionTriggerType
    {
        SelectRow,
        Maximize
    }

    public partial class Action
    {
        public DashboardActionTargetType Type { get; set; } = DashboardActionTargetType.OpenDashboard;
        public string Title { get; set; }
        public string Url { get; set; }
        public List<ActionParameter> Parameters { get; set; } = new List<ActionParameter>();     
    }

    public enum DashboardActionTargetType
    {
        OpenDashboard,
        OpenUrl
    }

    public class ActionParameter
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public DashboardActionParameterSourceType Type { get; set; } = DashboardActionParameterSourceType.Column;
        public string Value { get; set; }
    }

    public enum DashboardActionParameterSourceType
    {
        Column,
        Literal,
        GlobalFilter
    }
}
