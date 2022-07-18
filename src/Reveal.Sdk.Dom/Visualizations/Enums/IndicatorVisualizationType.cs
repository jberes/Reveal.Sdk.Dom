namespace Reveal.Sdk.Dom.Visualizations
{
    //todo: we may be able to remove this and replace it with specific enums
    internal enum IndicatorVisualizationType
    {
        YearToDatePreviousYear, //KpiTimePeriod
        QuarterToDatePreviousQuarter, //KpiTimePeriod
        QuarterToDatePreviousYear, //KpiTimePeriod
        MonthToDatePreviousMonth, //KpiTimePeriod
        MonthToDatePreviousYear, //KpiTimePeriod
        LastYears, //todo: what uses this?
        LastQuarters, //todo: what uses this?
        LastMonths, //SparklineAggregationType
        LastDays, //SparklineAggregationType
        LastHours, //todo: what uses this?
        LastMinutes //todo: what uses this?
    }
}
