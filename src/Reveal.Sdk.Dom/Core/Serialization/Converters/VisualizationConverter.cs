using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using System;
using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class VisualizationConverter : CustomJsonConverter<Visualization>
    {
        public override Visualization ReadJson(JsonReader reader, Type objectType, Visualization existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var visualizationSettings = jObject["VisualizationSettings"];
            var visualizationType = visualizationSettings["_type"].Value<string>();
            Type vizType = visualizationType switch
            {          
                SchemaTypeNames.AssetVisualizationSettingsType => typeof(ImageVisualization),
                SchemaTypeNames.ChartVisualizationSettingsType => GetChartVisualizationType(visualizationSettings),
                SchemaTypeNames.DiyVisualizationSettingsType => typeof(CustomVisualization),
                SchemaTypeNames.GaugeVisualizationSettingsType => GetGaugeVisualizationType(visualizationSettings),
                SchemaTypeNames.GridVisualizationSettingsType => typeof(GridVisualization),
                SchemaTypeNames.IndicatorVisualizationSettingsType => typeof(KpiTimeVisualization),
                SchemaTypeNames.IndicatorTargetVisualizationSettingsType => typeof(KpiTargetVisualization),
                SchemaTypeNames.PivotVisualizationSettingsType => typeof(PivotVisualization),
                SchemaTypeNames.ScatterMapVisualizationSettingsType => typeof(ScatterMapVisualization),
                SchemaTypeNames.SingleRowVisualizationSettingsType => typeof(TextViewVisualization),
                SchemaTypeNames.SparklineVisualizationSettingsType => typeof(SparklineVisualization),
                SchemaTypeNames.TextBoxVisualizationSettingsType => typeof(TextBoxVisualization),
                SchemaTypeNames.TreeMapVisualizationSettingsType => typeof(TreeMapVisualization),
                SchemaTypeNames.ChoroplethMapVisualizationSettingsType => typeof(ChoroplethVisualization),
                _ => throw new JsonException($"Visualization not supported: {visualizationType}")
            };

            var item = Activator.CreateInstance(vizType, true);
            serializer.Populate(jObject.CreateReader(), item);
            return item as Visualization;
        }

        private static Type GetGaugeVisualizationType(JToken jToken)
        {
            var vs = jToken["ViewType"].Value<string>();
            Type type = vs switch
            {
                "BulletGraph" => typeof(BulletGraphVisualization),
                "Circular" => typeof(CircularGaugeVisualization),
                "Linear" => typeof(LinearGaugeVisualization),
                "SingleValue" => typeof(TextVisualization),
                _ => throw new JsonException($"Chart type not supported: {vs}")
            };
            return type;
        }

        Type GetChartVisualizationType(JToken jToken)
        {
            var chartType = jToken["ChartType"].Value<string>();
            Type type = chartType switch
            {
                "Area" => typeof(AreaChartVisualization),
                "Bar" => typeof(BarChartVisualization),
                "Bubble" => typeof(BubbleVisualization),
                "Candlestick" => typeof(CandleStickVisualization),
                "Column" => typeof(ColumnChartVisualization),
                "Composite" => typeof(ComboChartVisualization),
                "Doughnut" => typeof(DoughnutChartVisualization),
                "Funnel" => typeof(FunnelChartVisualization),
                "Line" => typeof(LineChartVisualization),
                "Pie" => typeof(PieChartVisualization),
                "RadialLines" => typeof(RadialVisualization),
                "Scatter" => typeof(ScatterVisualization),
                "Spline" => typeof(SplineChartVisualization),
                "SplineArea" => typeof(SplineAreaChartVisualization),
                "StackedArea" => typeof(StackedAreaChartVisualization),
                "StackedBar" => typeof(StackedBarChartVisualization),
                "StackedColumn" => typeof(StackedColumnChartVisualization),
                "StepArea" => typeof(StepAreaChartVisualization),
                "StepLine" => typeof(StepLineChartVisualization),
                "TimeSeries" => typeof(TimeSeriesVisualization),
                "OHLC" => typeof(OHLCVisualization),
                _ => throw new JsonException($"Chart type not supported: {chartType}")
            };

            return type;
        }
    }
}
