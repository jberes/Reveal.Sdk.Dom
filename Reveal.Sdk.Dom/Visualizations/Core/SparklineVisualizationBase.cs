using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class SparklineVisualizationBase<TSettings> : Visualization<TSettings, SparklineVisualizationDataSpec>
    where TSettings : VisualizationSettings, new()
    {
        protected SparklineVisualizationBase(DataSourceItem dataSourceItem) : base(dataSourceItem) { }

        [JsonIgnore]
        public DimensionColumnSpec Date
        {
            get { return GetVisualizationDataSpec().Date; }
            set { GetVisualizationDataSpec().Date = value; }
        }

        [JsonIgnore]
        public IndicatorVisualizationType IndicatorType
        {
            get { return GetVisualizationDataSpec().IndicatorType; }
            set { GetVisualizationDataSpec().IndicatorType = value; }
        }

        [JsonIgnore]
        public List<MeasureColumnSpec> Values
        {
            get { return GetVisualizationDataSpec().Value; }
        }

        //todo: confirm that the category is stored as rows
        [JsonIgnore]
        public List<DimensionColumnSpec> Categories
        {
            get { return GetVisualizationDataSpec().Rows; }
        }

        [JsonIgnore]
        public int NumberOfPeriods
        {
            get { return GetVisualizationDataSpec().NumberOfPeriods; }
            set { GetVisualizationDataSpec().NumberOfPeriods = value; }
        }

        [JsonIgnore]
        public bool ShowIndicator
        {
            get { return GetVisualizationDataSpec().ShowIndicator; }
            set { GetVisualizationDataSpec().ShowIndicator = value; }
        }
    }
}