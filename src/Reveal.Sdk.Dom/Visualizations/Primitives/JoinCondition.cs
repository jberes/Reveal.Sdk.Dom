namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class JoinCondition
    {
        public JoinCondition(string leftFieldName, string rightFieldName)
        {
            LeftFieldName = leftFieldName;
            RightFieldName = rightFieldName;
        }

        public JoinCondition() { }

        public string LeftFieldName { get; set; }
        public string RightFieldName { get; set; }
    }
}
