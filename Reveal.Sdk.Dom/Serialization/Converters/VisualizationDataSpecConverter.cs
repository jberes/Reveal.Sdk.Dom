using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Serialization.Converters
{
    internal class VisualizationDataSpecConverter : JsonConverter<VisualizationDataSpec>
    {
        public override VisualizationDataSpec Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerAtStart = reader;

            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDocument.RootElement;

            var type = jsonObject.GetProperty("_type").GetString();

            Type bindingSourceType = type switch
            {
                SchemaTypeNames.AssetVisualizationDataSpecType => typeof(AssetVisualizationDataSpec),
                SchemaTypeNames.BubbleVisualizationDataSpecType => typeof(BubbleVisualizationDataSpec),
                SchemaTypeNames.CategoryVisualizationDataSpecType => typeof(CategoryVisualizationDataSpec),
                SchemaTypeNames.ChoroplethMapVisualizationDataSpecType => typeof(ChoroplethMapVisualizationDataSpec),
                SchemaTypeNames.CompositeChartVisualizationDataSpecType => typeof(CompositeChartVisualizationDataSpec),
                SchemaTypeNames.FinancialVisualizationDataSpecType => typeof(FinancialVisualizationDataSpec),
                SchemaTypeNames.GridVisualizationDataSpecType => typeof(GridVisualizationDataSpec),
                SchemaTypeNames.IndicatorBaseVisualizationDataSpecType => typeof(IndicatorVisualizationDataSpecBase),
                SchemaTypeNames.IndicatorTargetVisualizationDataSpecType => typeof(KpiTargetVisualizationDataSpec),
                SchemaTypeNames.IndicatorVisualizationDataSpecType => typeof(IndicatorVisualizationDataSpec),
                SchemaTypeNames.LinearGaugeVisualizationDataSpecType => typeof(LinearGaugeVisualizationDataSpec),
                SchemaTypeNames.PivotVisualizationDataSpecType => typeof(PivotVisualizationDataSpec),
                SchemaTypeNames.ScatterMapVisualizationDataSpecType => typeof(ScatterMapVisualizationDataSpec),
                SchemaTypeNames.ScatterVisualizationDataSpecType => typeof(ScatterVisualizationDataSpec),
                SchemaTypeNames.SingleGaugeVisualizationDataSpecType => typeof(SingleGaugeVisualizationDataSpec),
                SchemaTypeNames.SingleValueCategoryVisualizationDataSpecType => typeof(SingleValueCategoryVisualizationDataSpec),
                SchemaTypeNames.SingleValueLabelsVisualizationDataSpecType => typeof(SingleValueLabelsVisualizationDataSpec),
                SchemaTypeNames.SingleValueVisualizationDataSpecType => typeof(SingleValueVisualizationDataSpec),
                SchemaTypeNames.SparklineVisualizationDataSpecType => typeof(SparklineVisualizationDataSpec),
                SchemaTypeNames.TreeMapVisualizationDataSpecType => typeof(TreeMapVisualizationDataSpec),
                _ => throw new JsonException($"VisualizationDataSpec not supported: {type}")
            };

            return JsonSerializer.Deserialize(ref readerAtStart, bindingSourceType, options) as VisualizationDataSpec;
        }

        public override void Write(Utf8JsonWriter writer, VisualizationDataSpec value, JsonSerializerOptions options)
        {
            if (value is IndicatorVisualizationDataSpec idc)
                JsonSerializer.Serialize(writer, idc, options);
            else if (value is KpiTargetVisualizationDataSpec iTarget)
                JsonSerializer.Serialize(writer, iTarget, options);
            else if (value is CategoryVisualizationDataSpec cat)
                JsonSerializer.Serialize(writer, cat, options);
            else if (value is SingleValueLabelsVisualizationDataSpec singleVL)
                JsonSerializer.Serialize(writer, singleVL, options);
            else if (value is LinearGaugeVisualizationDataSpec lgd)
                JsonSerializer.Serialize(writer, lgd, options);
            else if (value is PivotVisualizationDataSpec pivot)
                JsonSerializer.Serialize(writer, pivot, options);
            else if (value is SingleGaugeVisualizationDataSpec sgd)
                JsonSerializer.Serialize(writer, sgd, options);
            else
                throw new JsonException($"VisualizationDataSpec not supported: {value.GetType()}");
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(VisualizationDataSpec).IsAssignableFrom(typeToConvert);
        }
    }
}
