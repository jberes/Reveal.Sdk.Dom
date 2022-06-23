using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Serialization.Converters
{
    internal class VisualizationConverter : JsonConverter<Visualization>
    {
        public override Visualization Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerAtStart = reader;

            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDocument.RootElement;

            var visualizationSettings = jsonObject.GetProperty("VisualizationSettings");
            var visualizationType = visualizationSettings.GetProperty("_type").GetString();
            Type vizType = visualizationType switch
            {
                SchemaTypeNames.ChartVisualizationSettingsType => GetChartVsualizationType(visualizationSettings),
                SchemaTypeNames.IndicatorVisualizationSettingsType => typeof(IndicatorVisualization),
                SchemaTypeNames.IndicatorTargetVisualizationSettingsType => typeof(KpiTargetVisualization),
                SchemaTypeNames.PivotVisualizationSettingsType => typeof(PivotVisualization),
                SchemaTypeNames.SparklineVisualizationSettingsType => typeof(SparklineVisualization),
                SchemaTypeNames.GaugeVisualizationSettingsType => GetGaugeVisualizationType(jsonObject),
                _ => throw new JsonException($"Visualization not supported: {visualizationType}")
            };

            return JsonSerializer.Deserialize(ref readerAtStart, vizType, options) as Visualization;
        }

        private static Type GetGaugeVisualizationType(JsonElement jsonElement)
        {
            var vds = jsonElement.GetProperty("VisualizationDataSpec").GetProperty("_type").GetString();
            Type type = vds switch
            {
                "SingleGaugeVisualizationDataSpecType" => typeof(CircularGaugeVisualization),
                "LinearGaugeVisualizationDataSpecType" => typeof(GaugeVisualization),
                _ => throw new JsonException($"Chart type not supported: {vds}")
            };

            return type;
        }

        Type GetChartVsualizationType(JsonElement jsonElement)
        {
            var chartType = jsonElement.GetProperty("ChartType").GetString();
            Type type = chartType switch
            {
                "Bar" => typeof(BarChartVisualization),
                "Pie" => typeof(PieChartVisualization),
                "Line" => typeof(LineChartVisualization),
                "Column" => typeof(ColumnChartVisualization),
                "Funnel" => typeof(FunnelChartVisualization),
                "SplineArea" => typeof(SplineAreaChartVisualization),
                "StackedColumn" => typeof(StackedColumnChartVisualization),
                "Doughnut" => typeof(DoughnutChartVisualization),
                _ => throw new JsonException($"Chart type not supported: {chartType}")
            };

            return type;
        }

        public override void Write(Utf8JsonWriter writer, Visualization value, JsonSerializerOptions options)
        {
            if (value is GaugeVisualization gv)
                JsonSerializer.Serialize(writer, gv, options);
            else if (value is KpiTargetVisualization iTarget)
                JsonSerializer.Serialize(writer, iTarget, options);
            else if (value is IndicatorVisualization idc)
                JsonSerializer.Serialize(writer, idc, options);
            else if (value is PivotVisualization pivot)
                JsonSerializer.Serialize(writer, pivot, options);
            else if (value is BarChartVisualization bar)
                JsonSerializer.Serialize(writer, bar, options);
            else if (value is LineChartVisualization line)
                JsonSerializer.Serialize(writer, line, options);
            else if (value is PieChartVisualization pie)
                JsonSerializer.Serialize(writer, pie, options);
            else if (value is ColumnChartVisualization column)
                JsonSerializer.Serialize(writer, column, options);
            else if (value is FunnelChartVisualization funnel)
                JsonSerializer.Serialize(writer, funnel, options);
            else if (value is SplineAreaChartVisualization spline)
                JsonSerializer.Serialize(writer, spline, options);
            else if (value is StackedColumnChartVisualization stc)
                JsonSerializer.Serialize(writer, stc, options);
            else if (value is SparklineVisualization spk)
                JsonSerializer.Serialize(writer, spk, options);
            else if (value is DoughnutChartVisualization dnc)
                JsonSerializer.Serialize(writer, dnc, options);
            else if (value is CircularGaugeVisualization cgv)
                JsonSerializer.Serialize(writer, cgv, options);
            else
                throw new JsonException($"Visualization not supported: {value}");
        }
    }
}
