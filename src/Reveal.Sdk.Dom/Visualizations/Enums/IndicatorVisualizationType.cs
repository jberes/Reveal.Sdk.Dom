namespace Reveal.Sdk.Dom.Visualizations
{
    internal enum IndicatorVisualizationType
    {
        YearToDatePreviousYear, //KpiTimePeriod
        QuarterToDatePreviousQuarter, //KpiTimePeriod
        QuarterToDatePreviousYear, //KpiTimePeriod
        MonthToDatePreviousMonth, //KpiTimePeriod
        MonthToDatePreviousYear, //KpiTimePeriod
        LastYears, //SparklineAggregationType
        LastQuarters, //todo: what uses this?
        LastMonths, //SparklineAggregationType
        LastDays, //SparklineAggregationType
        LastHours, //todo: what uses this?
        LastMinutes //todo: what uses this?
    }
}
