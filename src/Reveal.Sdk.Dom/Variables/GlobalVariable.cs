namespace Reveal.Sdk.Dom.Variables
{
    //todo: will probably rename to dashboard variable
    internal sealed class GlobalVariable
    {
        public string Name { get; set; }
        public bool IsHidden { get; set; }
        public GlobalVariableValueType Type { get; set; } = GlobalVariableValueType.String;
        public object Value { get; set; }
    }
}
