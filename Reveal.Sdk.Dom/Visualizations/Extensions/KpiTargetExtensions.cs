using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IKpiTargetExtensions
    {
        public static T AddTarget<T>(this T visualization, string targeField)
            where T : IKpiTargetVisualization
        {
            visualization.Target.Add(new MeasureColumnSpec() { SummarizationField = new SummarizationValueField(targeField) });
            return visualization;
        }

        public static T AddTarget<T>(this T visualization, SummarizationValueField targetField)
            where T : IKpiTargetVisualization
        {
            visualization.Target.Add(new MeasureColumnSpec() { SummarizationField = targetField });
            return visualization;
        }

        public static T AddTargets<T>(this T visualization, params string[] targets)
            where T : IKpiTargetVisualization
        {
            foreach (var value in targets)
            {
                visualization.AddTarget(value);
            }
            return visualization;
        }

        public static T AddTargets<T>(this T visualization, params SummarizationValueField[] targets)
            where T : IKpiTargetVisualization
        {
            foreach (var value in targets)
            {
                visualization.AddTarget(value);
            }
            return visualization;
        }

        //todo: figure out how to share this across all visualizations in a generic way
        public static KpiTargetVisualization ConfigureSettings(this KpiTargetVisualization visualization, Action<KpiTargetVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }
    }
}
