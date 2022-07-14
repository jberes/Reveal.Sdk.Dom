namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IMapExtensions
    {
        public static T SetMap<T>(this T visualization, string map)
            where T: IMap
        {
            visualization.Map = map;
            return visualization;
        }
    }
}
