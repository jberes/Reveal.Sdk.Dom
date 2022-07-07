using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using Sandbox.Helpers;

namespace Sandbox.Factories
{
    internal class CustomDashboard
    {
        internal static DashboardDocument CreateDashboard()
        {
            var excelDataSourceItem = new ExcelBuilder("http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx")
                .SetTitle("Excel Data Source")
                .SetSubtitle("Marketing Sheet")
                .UseSheet("Marketing")
                .SetFields(DataSourceFactory.GetMarketingDataSourceFields())
                .IsAnonymous(true)
                .Build();

            var document = new DashboardDocument()
            {
                Title = "Custom Dashboard",
                Description = "Playing with the Fluent API",
                Theme = ThemeNames.TropicalIsland
            };

            //grid
            document.Visualizations.Add(new GridVisualization("Grid", excelDataSourceItem)
                .AddColumn("Territory").AddColumn("Conversions").AddColumn("Spend"));

            //text view
            document.Visualizations.Add(new TextViewVisualization("TextView", excelDataSourceItem)
                .AddColumn("Territory").AddColumn("Conversions").AddColumn("Spend"));

            //pivot
            document.Visualizations.Add(new PivotVisualization("Pivot", excelDataSourceItem)
                .AddRow("Territory").AddValue("New Seats").AddColumn("CampaignID"));

            //column
            document.Visualizations.Add(new ColumnChartVisualization("Column", excelDataSourceItem)
                .AddLabel("Date").AddValues("Paid Traffic", "Organic Traffic", "Other Traffic"));

            //bar
            document.Visualizations.Add(new BarChartVisualization("Bar", excelDataSourceItem)
                .AddLabel("Date").AddValues("Paid Traffic", "Organic Traffic", "Other Traffic"));

            //pie
            document.Visualizations.Add(new PieChartVisualization("Pie", excelDataSourceItem)
                .AddLabel("Territory").AddValue("Conversions"));

            //doughnut
            document.Visualizations.Add(new DoughnutChartVisualization("Doughnut", excelDataSourceItem)
                .AddLabel("Territory").AddValue("Conversions"));

            //funnel
            document.Visualizations.Add(new FunnelChartVisualization("Funnel", excelDataSourceItem)
                .AddLabel("Territory")
                .AddValue("Conversions"));

            //combo
            document.Visualizations.Add(new ComboChartVisualization("Combo", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .ConfigureChart1(config =>
                {
                    config.Values.Add("Spend"); //todo: maybe the extension should be AddValue and AddValues
                    config.ChartType = ChartType.Bar;
                })
                .ConfigureChart2(config =>
                {
                    config.Values.Add("Budget");
                    config.ChartType = ChartType.Line;
                }));

            //stacked column
            document.Visualizations.Add(new StackedColumnChartVisualization("Stacked Column", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Paid Traffic", "Organic Traffic", "Other Traffic"));

            //stacked bar
            document.Visualizations.Add(new StackedBarChartVisualization("Stacked Bar", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Paid Traffic", "Organic Traffic", "Other Traffic"));

            //stacked area
            document.Visualizations.Add(new StackedAreaChartVisualization("Stacked Area", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Paid Traffic", "Organic Traffic", "Other Traffic"));

            //area
            document.Visualizations.Add(new AreaChartVisualization("Area", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Paid Traffic", "Organic Traffic", "Other Traffic"));

            //line
            document.Visualizations.Add(new LineChartVisualization("Line", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValue("Conversions"));

            //step area
            document.Visualizations.Add(new StepAreaChartVisualization("Step Area", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Spend", "Budget"));

            //step line
            document.Visualizations.Add(new StepLineChartVisualization("Step Line", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Spend", "Budget"));

            //spline area
            document.Visualizations.Add(new SplineAreaChartVisualization("Spline Area", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Spend", "Budget"));

            //spline
            document.Visualizations.Add(new SplineChartVisualization("Spline", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Spend", "Budget"));

            //linear gauge
            document.Visualizations.Add(new LinearGaugeVisualization("Linear", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month }).AddValue("Spend"));

            //circular gauge
            document.Visualizations.Add(new CircularGaugeVisualization("Circular", excelDataSourceItem).AddLabel("Budget").AddValue("Spend"));

            //text
            document.Visualizations.Add(new TextVisualization("Text", excelDataSourceItem).AddLabel("Budget").AddValue("Spend"));

            //kpi target
            document.Visualizations.Add(new KpiTargetVisualization("KPI vs Target", excelDataSourceItem).AddDate("Date").AddValue("Spend").AddTarget("Budget"));

            //kpi time
            document.Visualizations.Add(new KpiTimeVisualization("KPI vs Time", excelDataSourceItem).AddDate("Date").AddValue("Traffic"));

            //bullet graph
            document.Visualizations.Add(new BulletGraphVisualization("Bullet Graph", excelDataSourceItem).AddLabel("CampaignID").AddValue("Spend").AddTarget("Budget"));

            //choropleth map
            //TBD

            //scatter map
            //TBD

            //tree map
            document.Visualizations.Add(new TreeMapVisualization("Tree Map", excelDataSourceItem)
                .AddLabel("Territory").AddValue("Traffic"));

            //bubble
            document.Visualizations.Add(new BubbleVisualization("Bubble", excelDataSourceItem)
                .AddLabel("CampaignID").AddXAxis("Budget").AddYAxis("Spend").AddRadius("Traffic"));

            //scatter
            document.Visualizations.Add(new ScatterVisualization("Scatter", excelDataSourceItem)
                .AddLabel("CampaignID").AddXAxis("Budget").AddYAxis("Spend"));

            //time series
            document.Visualizations.Add(new TimeSeriesVisualization("Time Series", excelDataSourceItem)
                .AddDate(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Paid Traffic", "Organic Traffic", "Other Traffic"));

            //radial
            document.Visualizations.Add(new RadialVisualization("Radial", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Spend", "Budget"));

            //image
            document.Visualizations.Add(new ImageVisualization("Image", excelDataSourceItem).SetUrlColumn("Territory"));

            //textbox
            document.Visualizations.Add(new TextBoxVisualization("TextBox").SetText("This is some text").SetFontSize(FontSize.Large));

            //DIY
            document.Visualizations.Add(new DiyVisualization("DIY", excelDataSourceItem)
                .SetUrl("https://dl.infragistics.com/reportplus/diy/HelloWorld-Desktop-EN.html")
                .AddRows("Territory", "CampaignID")
                .AddValues("Spend", "Budget"));

            //OHLC
            //TBD

            //Candle stick
            //TBD

            return document;
        }
    }
}