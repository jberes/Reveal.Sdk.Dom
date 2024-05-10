using Reveal.Sdk;
using Reveal.Sdk.Data;
using Reveal.Sdk.Data.Excel;
using Reveal.Sdk.Data.Json;
using Reveal.Sdk.Data.Microsoft.SqlServer;
using Reveal.Sdk.Data.Rest;
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using Sandbox.Factories;
using Sandbox.Helpers;
using Sandbox.RevealSDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Sandbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly string _dashboardFilePath = Path.Combine(Environment.CurrentDirectory, "Dashboards");

        //readonly string _readFilePath = Path.Combine(_dashboardFilePath, DashboardFileNames.Marketing);
        //readonly string _readFilePath = Path.Combine(_dashboardFilePath, "JB - New Infragistics Scorecard Test.rdash");
        readonly string _readFilePath = Path.Combine(_dashboardFilePath, "SqlServer-Dashboard.rdash");

        readonly string _saveJsonToPath = Path.Combine(_dashboardFilePath, "MyDashboard.json");
        readonly string _saveRdashToPath = Path.Combine(_dashboardFilePath, DashboardFileNames.MyDashboard);

        public MainWindow()
        {
            InitializeComponent();

            //RevealSdkSettings.EnableNewCharts = true;
            RevealSdkSettings.DataSourceProvider = new Sandbox.RevealSDK.DataSourceProvider();
            RevealSdkSettings.AuthenticationProvider = new AuthenticationProvider();
            RevealSdkSettings.DataSources.RegisterMicrosoftSqlServer().RegisterMicrosoftAnalysisServices();

            _revealView.LinkedDashboardProvider = (string dashboardId, string linkTitle) =>
            {
                var path = Path.Combine(_dashboardFilePath, $"{dashboardId}.rdash");
                if (File.Exists(path))
                    return new RVDashboard(path);

                return null;
            };

            //_revealView.DataSourcesRequested += RevealView_DataSourcesRequested;

            _revealView.DashboardSelectorRequested += RevealView_DashboardSelectorRequested;
        }

        private void RevealView_DataSourcesRequested(object sender, DataSourcesRequestedEventArgs e)
        {
            var ds = new List<RVDashboardDataSource>();
            var dsi = new List<RVDataSourceItem>();

            var restDS = new RVRESTDataSource();
            restDS.Title = "Excel to JSON";
            restDS.Subtitle = "Data Source";
            restDS.UseAnonymousAuthentication = true;
            restDS.Url = "https://excel2json.io/api/share/6e0f06b3-72d3-4fec-7984-08da43f56bb9";
            ds.Add(restDS);

            var restExcelDS = new RVRESTDataSource();
            restExcelDS.Title = "REST Excel";
            restExcelDS.Subtitle = "Samples.xlsz";
            restExcelDS.UseAnonymousAuthentication = true;
            restExcelDS.Url = "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx";
            ds.Add(restExcelDS);

            //var restDSI = new RVRESTDataSourceItem(restExcelDS);
            //restDSI.Title = "REST Data Source Item";
            //restDSI.Subtitle = "REST DSI Subtitle";

            //var excelDSI = new RVExcelDataSourceItem(restDSI);
            //excelDSI.Title = "Excel Data Source Item";
            //excelDSI.Subtitle = "Marketing Sheet";
            //excelDSI.Sheet = "Marketing";
            //dsi.Add(excelDSI);

            var sqlDS = new RVSqlServerDataSource();
            sqlDS.Title = "SQL Server Data Source";
            sqlDS.Subtitle = "SQL Server DS Subtitle";
            sqlDS.Host = "Brian-Desktop\\SQLEXPRESS";
            sqlDS.Database = "Northwind"; //this is required
            ds.Add(sqlDS);

            var sqlDSI = new RVSqlServerDataSourceItem(sqlDS);
            sqlDSI.Title = "SQL Server Data Source Item";
            sqlDSI.Subtitle = "SQL Server DSI Subtitle";
            sqlDSI.Table = "Customers";
            dsi.Add(sqlDSI);

            var webDS = new RVWebResourceDataSource();
            webDS.UseAnonymousAuthentication = true;
            webDS.Title = "Web Resource";
            webDS.Url = "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx";
            ds.Add(webDS);

            e.Callback(new RevealDataSources(ds, dsi, true));
        }

        private void RevealView_DashboardSelectorRequested(object sender, DashboardSelectorRequestedEventArgs e)
        {
            e.Callback("Campaigns");
        }

        private async void RevealView_SaveDashboard(object sender, DashboardSaveEventArgs e)
        {
            //var json = _revealView.Dashboard.ExportToJson();
            var path = Path.Combine(Environment.CurrentDirectory, $"Dashboards/{e.Name}.rdash");
            var data = await e.Serialize();
            var json = _revealView.Dashboard.ExportToJson();
            using (var output = File.Open(path, FileMode.OpenOrCreate))
            {
                output.Write(data, 0, data.Length);
            }

            e.SaveFinished();
        }

        private void Load_Dashboard(object sender, RoutedEventArgs e)
        {
            _revealView.Dashboard = new RVDashboard(_readFilePath);
        }

        private void Clear_Dashboard(object sender, RoutedEventArgs e)
        {
            _revealView.Dashboard = new RVDashboard();
        }

        private async void Read_Dashboard(object sender, RoutedEventArgs e)
        {
            var document = RdashDocument.Load(_readFilePath);
            var json = document.ToJsonString();
            _revealView.Dashboard = await RVDashboard.LoadFromJsonAsync(json);
        }

        private async void Create_Dashboard(object sender, RoutedEventArgs e)
        {
            //var document = MarketingDashboard.CreateDashboard();
            //var document = SalesDashboard.CreateDashboard();
            //var document = CampaignsDashboard.CreateDashboard();
            //var document = HealthcareDashboard.CreateDashboard();
            //var document = ManufacturingDashboard.CreateDashboard();
            //var document = CustomDashboard.CreateDashboard();
            //var document = RestDataSourceDashboards.CreateDashboard();
            //var document = SqlServerDataSourceDashboards.CreateDashboard();
            //var document = DashboardLinkingDashboard.CreateDashboard();

            //document.Save(_saveRdashToPath);

            var document = new RdashDocument()
            {
                Title = "My Dashboard",
                Description = "I created"
            };

            //var dsi = new TabularDataFactory().Create(DataSourceType.REST, "Excel to JSON", "Sales")
            //    .SetId("TEST-ID")
            //    .SetFields(new List<IField>
            //    {
            //       new TextField("CategoryName"),
            //       new TextField("ProductName"),
            //       new NumberField("ProductSales")
            //    })
            //    .As<IRestBuilder>()
            //    .SetUri("https://excel2json.io/api/share/6e0f06b3-72d3-4fec-7984-08da43f56bb9")
            //    .Build();

            //var gridViz = new GridVisualization("REST", dsi).SetColumns("CategoryName", "ProductName", "ProductSales");
            //document.Visualizations.Add(gridViz);

            //var restExcel = new DataSourceItemFactory().Create(DataSourceType.REST, "REST Excel", "Marketing")
            //    .SetId("TEST-ID")
            //    .SetFields(new List<IField>
            //    {
            //        new TextField("CampaignID"),
            //        new TextField("Budget"),
            //    })
            //    .ConfigureDataSource(ds =>
            //    {
            //        ds.Title = "Excel";
            //        ds.Subtitle = "Data Source";
            //    })
            //    .As<IRestBuilder>()
            //    .SetUri("http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx")
            //    .As<IRestBuilder>().UseExcel("Marketing")
            //    .Build();

            //var gridViz = new GridVisualization("REST", restExcel).SetColumns("CampaignID", "Budget");
            //document.Visualizations.Add(gridViz);

            var sqlServer = new DataSourceItemFactory().Create(DataSourceType.MicrosoftSqlServer, "SQL Server Data Source Item", "SQL Server DSI Subtitle", new DataSource()
            {
                Title = "SQL Server Data Source",
            })
                .SetFields(new List<IField>
                {
                   new TextField("ContactName"),
                   new TextField("ContactTitle"),
                   new TextField("City")
                })
                .As<ISqlBuilder>()
                .SetHost(@"Brian-Desktop\SQLEXPRESS")
                .SetDatabase("Northwind")
                .SetTable("Customers")
                .Build();

            var gridViz2 = new GridVisualization("Sql Server", sqlServer).SetColumns("ContactName", "ContactTitle", "City");
            document.Visualizations.Add(gridViz2);

            var json = document.ToJsonString();
            //json.Save(_saveJsonToPath);
            _revealView.Dashboard = await RVDashboard.LoadFromJsonAsync(json);
        }
    }
}
