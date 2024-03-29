using Reveal.Sdk;
using Reveal.Sdk.Data;
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using Sandbox.Factories;
using Sandbox.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Sandbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly string _dashboardFilePath = Path.Combine(Environment.CurrentDirectory, "Dashboards");

        //readonly string _readFilePath = Path.Combine(_dashboardFilePath, DashboardFileNames.Marketing);
        readonly string _readFilePath = Path.Combine(_dashboardFilePath, "JB - New Infragistics Scorecard Test.rdash");

        readonly string _saveJsonToPath = Path.Combine(_dashboardFilePath, "MyDashboard.json");
        readonly string _saveRdashToPath = Path.Combine(_dashboardFilePath, DashboardFileNames.MyDashboard);

        public MainWindow()
        {
            InitializeComponent();

            //RevealSdkSettings.EnableNewCharts = true;
            RevealSdkSettings.AuthenticationProvider = new AuthenticationProvider();
            RevealSdkSettings.DataSources.RegisterMicrosoftSqlServer().RegisterMicrosoftAnalysisServices();
            RevealSdkSettings.DataSourceProvider = new DataSourceProvider();

            _revealView.LinkedDashboardProvider = (string dashboardId, string linkTitle) =>
            {
                var path = Path.Combine(_dashboardFilePath, $"{dashboardId}.rdash");
                if (File.Exists(path))
                    return new RVDashboard(path);

                return null;
            };

            _revealView.DataSourcesRequested += RevealView_DataSourcesRequested;

            _revealView.DashboardSelectorRequested += RevealView_DashboardSelectorRequested;
        }

        private void RevealView_DataSourcesRequested(object sender, DataSourcesRequestedEventArgs e)
        {
            var ds = new List<RVDashboardDataSource>();
            var dsi = new List<RVDataSourceItem>();

            var restDS = new RVRESTDataSource();
            restDS.Title = "Excel to JSON";
            restDS.UseAnonymousAuthentication = true;
            restDS.Url = "https://excel2json.io/api/share/6e0f06b3-72d3-4fec-7984-08da43f56bb9";
            ds.Add(restDS);

            var sqlDS = new RVSqlServerDataSource();
            sqlDS.Title = "SQL Server";
            sqlDS.Host = "Brian-Desktop\\SQLEXPRESS";
            ds.Add(sqlDS);

            var webDS = new RVWebResourceDataSource();
            webDS.UseAnonymousAuthentication = true;
            webDS.Title = "Web Resource";
            webDS.Url = "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx";
            ds.Add(webDS);

            e.Callback(new RevealDataSources(ds, dsi, false));
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

            //var dsi = new RestBuilder("Excel Data Source", "Marketing Sheet")
            //    .SetUrl("https://excel2json.io/api/share/6e0f06b3-72d3-4fec-7984-08da43f56bb9")
            //    .SetFields(
            //        new TextField("CategoryName"),
            //        new TextField("ProductName"),
            //        new NumberField("ProductSales")
            //    ).Build();

            //var dsi = Reveal.Sdk.Dom.Data.DataSourceFactory.Create(DataSourceType.REST, "Excel Data Source", "Marketing Sheet")
            //    .SetFields(new List<IField>
            //    {
            //        new TextField("CategoryName"),
            //        new TextField("ProductName"),
            //        new NumberField("ProductSales")
            //    }).Build();

            var dsi = new RemoteFileBuilder("Excel Data Source", "Marketing Sheet")
                .SetUrl("http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx")
                .UseExcel("Marketing")
                .SetFields(new List<IField>
                {
                    new DateField("Date"),
                    new NumberField("Spend"),
                    new NumberField("Budget"),
                    new NumberField("CTR"),
                    new NumberField("Avg. CPC"),
                    new NumberField("Traffic"),
                    new NumberField("Paid Traffic"),
                    new NumberField("Other Traffic"),
                    new NumberField("Conversions"),
                    new TextField("Territory"),
                    new TextField("CampaignID"),
                    new NumberField("New Seats"),
                    new NumberField("Paid %"),
                    new NumberField("Organic %")
                }).Build();


            var document = new RdashDocument()
            {
                Title = "My Dashboard",
                Description = "I created"
            };

            //var gridViz = new GridVisualization(dsi).SetColumns("CategoryName", "ProductName", "ProductSales");
            var gridViz = new GridVisualization(dsi).SetColumns("Spend", "Budget", "CTR");
            document.Visualizations.Add(gridViz);

            var json = document.ToJsonString();
            //json.Save(_saveJsonToPath);
            _revealView.Dashboard = await RVDashboard.LoadFromJsonAsync(json);
        }
    }

    public class DataSourceProvider : IRVDataSourceProvider
    {
        public Task<RVDataSourceItem> ChangeDataSourceItemAsync(RVDataSourceItem dataSourceItem)
        {
            if (dataSourceItem is RVJsonDataSourceItem jsonDataSourceItem)
            {
                var restDataSourceItem = jsonDataSourceItem.ResourceItem as RVRESTDataSourceItem;
                restDataSourceItem.Url = "https://excel2json.io/api/share/6e0f06b3-72d3-4fec-7984-08da43f56bb9";
            }
            return Task.FromResult(dataSourceItem);
        }


    }
}
