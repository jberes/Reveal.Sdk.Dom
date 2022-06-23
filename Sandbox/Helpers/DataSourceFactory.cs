using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System;
using System.Collections.Generic;

namespace Sandbox.Helpers
{
    internal class DataSourceFactory
    {
        static readonly ExcelDataSource _excelDataSource = new ExcelDataSource("http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx")
        {
            Title = "Excel Data Source",
            Subtitle = "This is a subtitle",
        };

        internal static ExcelDataSourceItem GetMarketingDataSourceItem()
        {
            var excelDataSourceItem = new ExcelDataSourceItem(_excelDataSource, "Marketing", GetMarketingDataSourceFields())
            {
                Subtitle = "Marketing Sheet",
            };

            return excelDataSourceItem;
        }

        internal static ExcelDataSourceItem GetHealthcareDataSourceItem()
        {
            var excelDataSourceItem = new ExcelDataSourceItem(_excelDataSource, "Healthcare", GetHealthcareDataSourceFields())
            {
                Subtitle = "Healthcare Sheet",
            };

            return excelDataSourceItem;
        }

        internal static ExcelDataSourceItem GetManufacturingDataSourceItem()
        {
            var excelDataSourceItem = new ExcelDataSourceItem(_excelDataSource, "Manufacturing", GetManufacturingDataSourceFields())
            {
                Subtitle = "Manufacturing Sheet",
            };

            return excelDataSourceItem;
        }

        internal static ExcelDataSourceItem GetSalesDataSourceItem()
        {
            var excelDataSourceItem = new ExcelDataSourceItem(_excelDataSource, "Sales", GetSalesDataSourceFields())
            {
                Subtitle = "Sales Sheet",
            };

            return excelDataSourceItem;
        }

        internal static List<Field> GetHealthcareDataSourceFields()
        {
            List<Field> fields = new List<Field>
            {
                new Field("Date")
                {
                    DataType = DataType.Date,
                },
                new Field("Number of Inpatients")
                {
                    DataType = DataType.Number,
                },
                new Field("Number of Outpatients")
                {
                    DataType = DataType.Number,
                },
                new Field("Treatment Costs ")
                {
                    DataType = DataType.Number,
                },
                new Field("ER Wait Time")
                {
                    DataType = DataType.Number,
                },
                new Field("Divison")
                {
                    DataType = DataType.String,
                },
                new Field("Satisfaction")
                {
                    DataType = DataType.String,
                },
                new Field("Length of Stay ")
                {
                    DataType = DataType.Number,
                },
                new Field("Charges per MD")
                {
                    DataType = DataType.Number,
                },
                new Field("Current Paitents")
                {
                    DataType = DataType.Number,
                },
            };

            return fields;
        }

        internal static List<Field> GetManufacturingDataSourceFields()
        {
            List<Field> fields = new List<Field>
            {
                new Field("Date")
                {
                    DataType = DataType.Date,
                },
                new Field("Units Lost")
                {
                    DataType = DataType.Number,
                },
                new Field("Overall Plant Productivity ")
                {
                    DataType = DataType.Number,
                },
                new Field("Operators Available ")
                {
                    DataType = DataType.Number,
                },
                new Field("Operators by Function")
                {
                    DataType = DataType.String,
                },
                new Field("Units Produced")
                {
                    DataType = DataType.Number,
                },
                new Field("Product")
                {
                    DataType = DataType.String,
                },
                new Field("Efficiency")
                {
                    DataType = DataType.Number,
                },
                new Field("Line")
                {
                    DataType = DataType.String,
                },
                new Field("Orders In")
                {
                    DataType = DataType.Number,
                },
                new Field("Orders Shipped ")
                {
                    DataType = DataType.Number,
                },
                new Field("Cost of Labor ")
                {
                    DataType = DataType.Number,
                },
                new Field("Revenue")
                {
                    DataType = DataType.Number,
                },
            };

            return fields;
        }

        internal static List<Field> GetMarketingDataSourceFields()
        {
            List<Field> fields = new List<Field>
            {
                new Field("Date")
                {
                    DataType = DataType.Date,
                },
                new Field("Spend")
                {
                    DataType = DataType.Number,
                },
                new Field("Budget")
                {
                    DataType = DataType.Number,
                },
                new Field("CTR")
                {
                    DataType = DataType.Number,
                },
                new Field("Avg. CPC")
                {
                    DataType = DataType.Number,
                },
                new Field("Traffic")
                {
                    DataType = DataType.Number,
                },
                new Field("Paid Traffic")
                {
                    DataType = DataType.Number,
                },
                new Field("Other Traffic")
                {
                    DataType = DataType.Number,
                },
                new Field("Conversions")
                {
                    DataType = DataType.Number,
                },
                new Field("Territory")
                {
                    DataType = DataType.String,
                },
                new Field("CampaignID")
                {
                    DataType = DataType.String,
                },
                new Field("New Seats")
                {
                    DataType = DataType.Number,
                },
                new Field("Paid %")
                {
                    DataType = DataType.Number,
                },
                new Field("Organic %")
                {
                    DataType = DataType.Number,
                }
            };

            return fields;
        }

        internal static List<Field> GetSalesDataSourceFields()
        {
            List<Field> fields = new List<Field>
            {
                new Field("Territory"),
                new Field("Date")
                {
                    DataType = DataType.Date,
                },
                new Field("Quota")
                {
                    DataType = DataType.Number,
                },
                new Field("Leads")
                {
                    DataType = DataType.Number,
                },
                new Field("Hot Leads")
                {
                    DataType = DataType.Number,
                },
                new Field("New Seats")
                {
                    DataType = DataType.Number,
                },
                new Field("New Sales")
                {
                    DataType = DataType.Number,
                },
                new Field("Renewal Seats")
                {
                    DataType = DataType.Number,
                },
                new Field("Renewal Sales ")
                {
                    DataType = DataType.Number,
                },
                new Field("Employee"),
                new Field("Pipepline")
                {
                    DataType = DataType.Number,
                },
                new Field("Forecasted")
                {
                    DataType = DataType.Number,
                },
                new Field("Revenue")
                {
                    DataType = DataType.Number,
                },
                new Field("Total Opportunites")
                {
                    DataType = DataType.Number,
                },
                new Field("Product"),
                new Field("b"),
                new Field("c"),
                new Field("d"),
                new Field("e"),
                new Field("f")
            };

            return fields;
        }
    }
}
