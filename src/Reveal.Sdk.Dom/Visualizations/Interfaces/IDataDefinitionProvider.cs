namespace Reveal.Sdk.Dom.Visualizations
{
    public interface IDataDefinitionProvider<out TDataDefinition> 
        where TDataDefinition : DataDefinitionBase
    {
        TDataDefinition DataDefinition { get; }
    }
}