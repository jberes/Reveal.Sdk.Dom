using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class ConditionalFormattingBase<TBand>
        where TBand : Band, new()
    {
        public ConditionalFormattingBase()
        {
            Bands = new List<TBand>()
            {
                UpperBand,
                MiddleBand,
                LowerBand
            };
        }
        
        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
        internal List<TBand> Bands { get; set; }

        /// <summary>
        /// Gets the formatting band for values that are greater than or equal to the <see cref="UpperBand"/> value.
        /// </summary>
        [JsonIgnore]
        public TBand UpperBand { get; } = new TBand() { Color = BandColor.Green, Value = 80.0 };

        /// <summary>
        /// Gets the formatting band for values that are greater than or equal to the <see cref="MiddleBand"/> value, and less than the <see cref="UpperBand"/> value.
        /// </summary>
        [JsonIgnore]
        public TBand MiddleBand { get; } = new TBand() { Color = BandColor.Yellow, Value = 50.0 };

        /// <summary>
        /// Gets the formatting band for values that are less than the <see cref="MiddleBand"/> value.
        /// </summary>
        [JsonIgnore]
        public TBand LowerBand { get; } = new TBand() { Color = BandColor.Red };

        [JsonIgnore]
        public ValueComparisonType ValueComparisonType
        {
            get { return Bands.First().ValueComparisonType; }
            set
            {
                foreach (var item in Bands)
                {
                    item.ValueComparisonType = value;
                }
            }
        }
    }
}
