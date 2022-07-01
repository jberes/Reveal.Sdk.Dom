using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Data.Builders;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;

namespace Sandbox.Helpers
{
    internal class DataSourceFactory
    {
        static readonly ExcelDataSource _excelDataSource = new ExcelDataSource("http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx")
        {
            Title = "Excel Data Source",
        };

        internal static DataSourceItem GetMarketingDataSourceItem()
        {
            var excelDataSourceItem = new DSIBuilder().UseExcel(_excelDataSource)
                .SetSubtitle("Marketing Sheet")
                .UseSheet("Marketing")
                .SetFields(GetMarketingDataSourceFields())
                .IsAnonymous(true)
                .Build();

            return excelDataSourceItem;
        }

        internal static DataSourceItem GetHealthcareDataSourceItem()
        {
            var excelDataSourceItem = new DSIBuilder().UseExcel(_excelDataSource)
                .SetSubtitle("Healthcare Sheet")
                .UseSheet("Healthcare")
                .SetFields(GetHealthcareDataSourceFields())
                .IsAnonymous(true)
                .Build();

            return excelDataSourceItem;
        }

        internal static DataSourceItem GetManufacturingDataSourceItem()
        {
            var excelDataSourceItem = new DSIBuilder().UseExcel(_excelDataSource)
                .SetSubtitle("Manufacturing Sheet")
                .UseSheet("Manufacturing")
                .SetFields(GetManufacturingDataSourceFields())
                .IsAnonymous(true)
                .Build();

            return excelDataSourceItem;
        }

        internal static DataSourceItem GetSalesDataSourceItem()
        {
            //var excelDataSourceItem = new ExcelDataSourceItem(_excelDataSource, "Sales", GetSalesDataSourceFields())
            //{
            //    Subtitle = "Sales Sheet",
            //};

            var excelDataSourceItem = new DSIBuilder().UseExcel(_excelDataSource)
                .SetSubtitle("Sales Sheet")
                .UseSheet("Sales")
                .SetFields(GetSalesDataSourceFields())
                .IsAnonymous(true)
                .Build();

            return excelDataSourceItem;
        }

        internal static List<Field> GetHealthcareDataSourceFields()
        {
            List<Field> fields = new List<Field>
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
            return fields;
        }

        internal static List<Field> GetManufacturingDataSourceFields()
        {
            List<Field> fields = new List<Field>
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

            return fields;
        }

        internal static List<Field> GetMarketingDataSourceFields()
        {
            List<Field> fields = new List<Field>
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
            return fields;
        }

        internal static List<Field> GetSalesDataSourceFields()
        {
            List<Field> fields = new List<Field>
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
            return fields;
        }
    }
}
