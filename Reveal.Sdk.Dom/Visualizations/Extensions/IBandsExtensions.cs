using Reveal.Sdk.Dom.Visualizations.Primitives;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IBandsExtensions
    {
        public static T AddBand<T>(this T visualization, GaugeBand band)
            where T : IBands
        {
            visualization.Bands.Add(band);
            return visualization;
        }

        //todo: we should probably only keep this if we have default bands to modify
        //public static T ConfigureBands<T>(this T visualization, Action<IList<GaugeBand>> bands)
        //    where T : IBands
        //{
        //    bands.Invoke(visualization.Bands);
        //    return visualization;
        //}
    }
}
