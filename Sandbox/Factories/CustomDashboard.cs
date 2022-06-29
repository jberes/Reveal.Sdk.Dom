using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Visualizations;
using Sandbox.Helpers;

namespace Sandbox.Factories
{
    internal class CustomDashboard
    {
        internal static DashboardDocument CreateDashboard()
        {
            var excelDataSourceItem = DataSourceFactory.GetMarketingDataSourceItem();

            var document = new DashboardDocument()
            {
                Title = "Custom Dashboard",
                Description = "Playing with the VisualizationFactory",
                Theme = ThemeNames.TropicalIsland
            };

            //grids
            document.Visualizations.Add(new GridVisualization("Grid", excelDataSourceItem)
                .AddColumn("Territory").AddColumn("Conversions").AddColumn("Spend"));

            document.Visualizations.Add(new TextViewVisualization("TextView", excelDataSourceItem)
                .AddColumn("Territory").AddColumn("Conversions").AddColumn("Spend"));

            document.Visualizations.Add(new PivotVisualization("Pivot", excelDataSourceItem)
                .AddRow("Territory").AddValue("New Seats").AddColumn("CampaignID"));

            //category
            document.Visualizations.Add(new ColumnChartVisualization("Column", excelDataSourceItem)
                .AddLabel("Date").AddValues("Paid Traffic", "Organic Traffic", "Other Traffic"));

            document.Visualizations.Add(new BarChartVisualization("Bar", excelDataSourceItem)
                .AddLabel("Date").AddValues("Paid Traffic", "Organic Traffic", "Other Traffic"));

            document.Visualizations.Add(new PieChartVisualization("Pie", excelDataSourceItem)
                .AddLabel("Territory").AddValue("Conversions"));

            document.Visualizations.Add(new DoughnutChartVisualization("Doughnut", excelDataSourceItem)
                .AddLabel("Territory").AddValue("Conversions"));

            document.Visualizations.Add(new FunnelChartVisualization("Funnel", excelDataSourceItem)
                .AddLabel("Territory")
                .AddValue("Conversions"));

            document.Visualizations.Add(new ComboChartVisualization("Combo", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddChart1Value("Spend")
                .AddChart2Value("Budget"));

            document.Visualizations.Add(new StackedColumnChartVisualization("Stacked Column", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Paid Traffic", "Organic Traffic", "Other Traffic"));

            document.Visualizations.Add(new StackedBarChartVisualization("Stacked Bar", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Paid Traffic", "Organic Traffic", "Other Traffic"));

            document.Visualizations.Add(new StackedAreaChartVisualization("Stacked Area", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Paid Traffic", "Organic Traffic", "Other Traffic"));

            document.Visualizations.Add(new AreaChartVisualization("Area", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Paid Traffic", "Organic Traffic", "Other Traffic"));

            document.Visualizations.Add(new LineChartVisualization("Line", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValue("Conversions"));

            document.Visualizations.Add(new StepAreaChartVisualization("Step Area", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Spend", "Budget"));

            document.Visualizations.Add(new StepLineChartVisualization("Step Line", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Spend", "Budget"));

            document.Visualizations.Add(new SplineAreaChartVisualization("Spline Area", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Spend", "Budget"));

            document.Visualizations.Add(new SplineChartVisualization("Spline", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Spend", "Budget"));

            //gauges
            document.Visualizations.Add(new LinearGaugeVisualization("Linear", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month }).AddValue("Spend"));

            document.Visualizations.Add(new CircularGaugeVisualization("Circular", excelDataSourceItem).AddLabel("Budget").AddValue("Spend"));

            document.Visualizations.Add(new TextVisualization("Text", excelDataSourceItem).AddLabel("Budget").AddValue("Spend"));

            document.Visualizations.Add(new KpiTargetVisualization("KPI vs Target", excelDataSourceItem).AddDate("Date").AddValue("Spend").AddTarget("Budget"));

            document.Visualizations.Add(new KpiTimeVisualization("KPI vs Time", excelDataSourceItem).AddDate("Date").AddValue("Traffic"));

            document.Visualizations.Add(new BulletGraphVisualization("KPI vs Target", excelDataSourceItem).AddLabel("CampaignID").AddValue("Spend").AddTarget("Budget"));

            //maps

            //scatter
            document.Visualizations.Add(new BubbleVisualization("Bubble", excelDataSourceItem)
                .AddLabel("CampaignID").AddXAxis("Budget").AddYAxis("Spend").AddRadius("Traffic"));

            document.Visualizations.Add(new ScatterVisualization("Scatter", excelDataSourceItem)
                .AddLabel("CampaignID").AddXAxis("Budget").AddYAxis("Spend"));

            //financial

            //time
            document.Visualizations.Add(new TimeSeriesVisualization("Time Series", excelDataSourceItem)
                .AddDate(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Paid Traffic", "Organic Traffic", "Other Traffic"));

            //other
            document.Visualizations.Add(new RadialVisualization("Radial", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Spend", "Budget"));

            document.Visualizations.Add(new ImageVisualization("Image", excelDataSourceItem).SetUrlColumn("Territory"));

            document.Visualizations.Add(new TextBoxVisualization("TextBox").SetText("This is some text").SetFontSize(FontSize.Large));

            document.Visualizations.Add(new DiyVisualization("DIY", excelDataSourceItem)
                .SetUrl("https://dl.infragistics.com/reportplus/diy/HelloWorld-Desktop-EN.html")
                .AddRows("Territory", "CampaignID")
                .AddValues("Spend", "Budget"));

            return document;
        }
    }
}