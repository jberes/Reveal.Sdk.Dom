using System;
using System.Collections.Generic;
using System.Linq;

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

        public static T ConfigureBands<T>(this T visualization, Action<IList<GaugeBand>> bands)
            where T : IBands
        {
            bands.Invoke(visualization.Bands);
            return visualization;
        }

        public static T ConfigureBands<T>(this T visualization, Action<GaugeBand, GaugeBand, GaugeBand> defaultBands)
            where T : IBands
        {
            var greenBand = visualization.Bands.Where(x => x.Color == BandColorType.Green).FirstOrDefault();
            var yellowBand = visualization.Bands.Where(x => x.Color == BandColorType.Yellow).FirstOrDefault();
            var redBand = visualization.Bands.Where(x => x.Color == BandColorType.Red).FirstOrDefault();

            defaultBands.Invoke(greenBand, yellowBand, redBand);
            return visualization;
        }
    }
}
