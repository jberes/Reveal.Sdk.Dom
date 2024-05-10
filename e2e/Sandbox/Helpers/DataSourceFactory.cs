using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;

namespace Sandbox.Helpers
{
    internal class DataSourceFactory
    {
        static IDataSourceItemFactory _factory = new DataSourceItemFactory();
        static DataSource _excelDataSource = new DataSource()
        {
            Id = "RestExcel",
            Title = "Excel Data Source",
            Subtitle = "The Data Source for Excel via REST",
        };

        static string _restExcelUri = "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx";    

        internal static DataSourceItem GetMarketingDataSourceItem()
        {
            //var excelDataSourceItem = new RestServiceBuilder("http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx")
            //    .SetTitle("Excel Data Source")
            //    .SetSubtitle("Marketing Sheet")
            //    .UseExcel("Marketing")
            //    .SetFields(GetMarketingDataSourceFields())
            //    .Build();

            var excelDataSourceItem = _factory.Create(DataSourceType.REST, _excelDataSource, "Excel Data Source Item")
                .Subtitle("Excel Data Source Item")
                .Fields(GetMarketingDataSourceFields())
                .As<IRestBuilder>()
                .Uri(_restExcelUri)
                .IsAnonymous(true)
                .UseExcel("Marketing")
                .Build();

            //var excelDataSourceItem = new RestBuilder(_excelDataSource, "Marketing Sheet")
            //    .SetUri(_restExcelUri)
            //    .IsAnonymous(true)
            //    .UseExcel("Marketing")
            //    .SetSubtitle("Excel Data Source Item")
            //    .SetFields(GetMarketingDataSourceFields())
            //    .Build();

            return excelDataSourceItem;
        }

        internal static DataSourceItem GetHealthcareDataSourceItem()
        {
            //var excelDataSourceItem = new RestServiceBuilder("http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx")
            //    .SetTitle("Excel Data Source")
            //    .SetSubtitle("Healthcare Sheet")
            //    .UseExcel("Healthcare")
            //    .SetFields(GetHealthcareDataSourceFields())
            //    .Build();

            var excelDataSourceItem = new RestBuilder(_excelDataSource, "Healthcare Sheet")
                .Uri(_restExcelUri)
                .IsAnonymous(true)
                .UseExcel("Healthcare")
                .Fields(GetHealthcareDataSourceFields())
                .Build();

            return excelDataSourceItem;
        }

        internal static DataSourceItem GetManufacturingDataSourceItem()
        {
            //var excelDataSourceItem = new RestServiceBuilder("http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx")
            //    .SetTitle("Excel Data Source")
            //    .SetSubtitle("Manufacturing Sheet")
            //    .UseExcel("Manufacturing")
            //    .SetFields(GetManufacturingDataSourceFields())
            //    .Build();

            var excelDataSourceItem = new RestBuilder(_excelDataSource, "Manufacturing Sheet")
                .Uri(_restExcelUri)
                .IsAnonymous(true)
                .UseExcel("Manufacturing")
                .Fields(GetManufacturingDataSourceFields())
                .Build();

            return excelDataSourceItem;
        }

        internal static DataSourceItem GetSalesDataSourceItem()
        {
            //var excelDataSourceItem = new RestServiceBuilder("http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx")
            //    .SetTitle("Excel Data Source")
            //    .SetSubtitle("Sales Sheet")
            //    .UseExcel("Sales")
            //    .SetFields(GetSalesDataSourceFields())
            //    .Build();

            var excelDataSourceItem = new RestBuilder(_excelDataSource, "Sales Sheet")
                .Uri(_restExcelUri)
                .IsAnonymous(true)
                .UseExcel("Sales")
                .Fields(GetSalesDataSourceFields())
                .Build();

            return excelDataSourceItem;
        }

        internal static IEnumerable<IField> GetRevenueDataSourceFields()
        {
            return new List<IField>()
            {
                new DateField("Date"),
                new TextField("State"),
                new NumberField("Revenue"),
                new NumberField("RevenueBudget"),
                new NumberField("RevenueBudgetLY"),
                new NumberField("GM"),
                new NumberField("GrossMarginLY"),
                new NumberField("GM%"),
                new NumberField("GrossMargin%LY"),
                new NumberField("RevenueperCompany"),
                new TextField("Company"),
                new TextField("Division")
            };
        }

        internal static List<IField> GetHealthcareDataSourceFields()
        {
            return new List<IField>
            {
                new DateField("Date"),
                new NumberField("Number of Inpatients"),
                new NumberField("Number of Outpatients"),
                new NumberField("Treatment Costs "),
                new NumberField("ER Wait Time"),
                new TextField("Divison"),
                new TextField("Satisfaction"),
                new NumberField("Length of Stay "),
                new NumberField("Charges per MD"),
                new NumberField("Current Paitents")
            };
        }

        internal static List<IField> GetManufacturingDataSourceFields()
        {
            return new List<IField>
            {
                new DateField("Date"),
                new NumberField("Units Lost"),
                new NumberField("Overall Plant Productivity "),
                new NumberField("Operators Available "),
                new TextField("Operators by Function"),
                new NumberField("Units Produced"),
                new TextField("Product"),
                new NumberField("Efficiency"),
                new TextField("Line"),
                new NumberField("Orders In"),
                new NumberField("Orders Shipped "),
                new NumberField("Cost of Labor "),
                new NumberField("Revenue")
            };
        }

        internal static List<IField> GetMarketingDataSourceFields()
        {
            return new List<IField>
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
            };
        }

        internal static List<IField> GetSalesDataSourceFields()
        {
            return new List<IField>
            {
                new TextField("Territory"),
                new DateField("Date"),
                new NumberField("Quota"),
                new NumberField("Leads"),
                new NumberField("Hot Leads"),
                new NumberField("New Seats"),
                new NumberField("New Sales"),
                new NumberField("Renewal Seats"),
                new NumberField("Renewal Sales "),
                new TextField("Employee"),
                new NumberField("Pipepline"),
                new NumberField("Forecasted"),
                new NumberField("Revenue"),
                new NumberField("Total Opportunites"),
                new TextField("Product")
            };
        }

        internal static List<IField> GetSalesByCategoryFields()
        {
            return new List<IField>
            {
                new NumberField("CategoryID"),
                new TextField("CategoryName"),
                new TextField("ProductName"),
                new NumberField("ProductSales"),
            };
        }

        internal static List<IField> GetCsvDataSourceFields()
        {
            return new List<IField>
            {
                new TextField("the_geom"),
                new NumberField("School_ID"),
                new TextField("School_Nm"),
                new TextField("Sch_Addr"),
                new TextField("Grade_Cat"),
                new TextField("Grades"),
                new TextField("Sch_Type"),
                new NumberField("X"),
                new NumberField("Y"),
            };
        }

        internal static IEnumerable<IField> GetOHLCDataSourceFields()
        {
            return new List<IField>
            {
                new DateField("Date"),
                new NumberField("Open"),
                new NumberField("High"),
                new NumberField("Low"),
                new NumberField("Close"),
                new NumberField("Volume"),
            };
        }
    }
}
