using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class VisualizationDataSpecConverter : TypeMapConverter<VisualizationDataSpec>
    {
        public VisualizationDataSpecConverter()
        {
            TypeMap = new System.Collections.Generic.Dictionary<string, Type>()
            {
                { SchemaTypeNames.AssetVisualizationDataSpecType, typeof(AssetVisualizationDataSpec) },
                { SchemaTypeNames.BubbleVisualizationDataSpecType, typeof(BubbleVisualizationDataSpec) },
                { SchemaTypeNames.CategoryVisualizationDataSpecType, typeof(CategoryVisualizationDataSpec) },
                { SchemaTypeNames.ChoroplethMapVisualizationDataSpecType, typeof(ChoroplethVisualizationDataSpec) },
                { SchemaTypeNames.CompositeChartVisualizationDataSpecType, typeof(CompositeChartVisualizationDataSpec) },
                { SchemaTypeNames.FinancialVisualizationDataSpecType, typeof(FinancialVisualizationDataSpec)},
                { SchemaTypeNames.GridVisualizationDataSpecType, typeof(GridVisualizationDataSpec) },
                { SchemaTypeNames.IndicatorBaseVisualizationDataSpecType, typeof(IndicatorBaseVisualizationDataSpec) },
                { SchemaTypeNames.IndicatorTargetVisualizationDataSpecType, typeof(IndicatorTargetVisualizationDataSpec) },
                { SchemaTypeNames.IndicatorVisualizationDataSpecType, typeof(IndicatorVisualizationDataSpec) },
                { SchemaTypeNames.LinearGaugeVisualizationDataSpecType, typeof(LinearGaugeVisualizationDataSpec) },
                { SchemaTypeNames.PivotVisualizationDataSpecType, typeof(PivotVisualizationDataSpec) },
                { SchemaTypeNames.ScatterMapVisualizationDataSpecType, typeof(ScatterMapVisualizationDataSpec) },
                { SchemaTypeNames.ScatterVisualizationDataSpecType, typeof(ScatterVisualizationDataSpec) },
                { SchemaTypeNames.SingleGaugeVisualizationDataSpecType, typeof(SingleGaugeVisualizationDataSpec) },
                { SchemaTypeNames.SingleValueCategoryVisualizationDataSpecType, typeof(SingleValueCategoryVisualizationDataSpec) },
                { SchemaTypeNames.SingleValueLabelsVisualizationDataSpecType, typeof(SingleValueLabelsVisualizationDataSpec) },
                { SchemaTypeNames.SingleValueVisualizationDataSpecType, typeof(SingleValueVisualizationDataSpec) },
                { SchemaTypeNames.SparklineVisualizationDataSpecType, typeof(SparklineVisualizationDataSpec) },
                { SchemaTypeNames.TimeSeriesVisualizationDataSpecType, typeof(TimeSeriesVisualizationDataSpec) },
                { SchemaTypeNames.TreeMapVisualizationDataSpecType, typeof(TreeMapVisualizationDataSpec) },
            };
        }
    }
}

