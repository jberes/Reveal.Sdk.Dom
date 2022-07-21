
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ILabelExtensions
    {
        public static T SetLabel<T>(this T visualization, string field)
            where T : ILabel
        {
            return visualization.SetLabel(new TextDataField(field));
        }

        public static T SetLabel<T>(this T visualization, DimensionDataField field)
            where T : ILabel
        {
            visualization.Label = new DimensionColumn()
            {
                DataField = field
            };
            return visualization;
        }
    }
}
