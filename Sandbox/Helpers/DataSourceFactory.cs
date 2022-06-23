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
                new Field()
                {
                    FieldName = "Date",
                    DataType = DataType.Date,
                },
                new Field()
                {
                    FieldName = "Number of Inpatients",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Number of Outpatients",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Treatment Costs ",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "ER Wait Time",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Divison",
                    DataType = DataType.String,
                },
                new Field()
                {
                    FieldName = "Satisfaction",
                    DataType = DataType.String,
                },
                new Field()
                {
                    FieldName = "Length of Stay ",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Charges per MD",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Current Paitents",
                    DataType = DataType.Number,
                },
            };

            return fields;
        }

        internal static List<Field> GetManufacturingDataSourceFields()
        {
            List<Field> fields = new List<Field>
            {
                new Field()
                {
                    FieldName = "Date",
                    DataType = DataType.Date,
                },
                new Field()
                {
                    FieldName = "Units Lost",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Overall Plant Productivity ",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Operators Available ",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Operators by Function",
                    DataType = DataType.String,
                },
                new Field()
                {
                    FieldName = "Units Produced",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Product",
                    DataType = DataType.String,
                },
                new Field()
                {
                    FieldName = "Efficiency",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Line",
                    DataType = DataType.String,
                },
                new Field()
                {
                    FieldName = "Orders In",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Orders Shipped ",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Cost of Labor ",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Revenue",
                    DataType = DataType.Number,
                },
            };

            return fields;
        }

        internal static List<Field> GetMarketingDataSourceFields()
        {
            List<Field> fields = new List<Field>
            {
                new Field()
                {
                    FieldName = "Date",
                    DataType = DataType.Date,
                },
                new Field()
                {
                    FieldName = "Spend",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Budget",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "CTR",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Avg. CPC",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Traffic",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Paid Traffic",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Other Traffic",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Conversions",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Territory",
                    DataType = DataType.String,
                },
                new Field()
                {
                    FieldName = "CampaignID",
                    DataType = DataType.String,
                },
                new Field()
                {
                    FieldName = "New Seats",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Paid %",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Organic %",
                    DataType = DataType.Number,
                }
            };

            return fields;
        }

        internal static List<Field> GetSalesDataSourceFields()
        {
            List<Field> fields = new List<Field>
            {
                new Field()
                {
                    FieldName = "Territory",
                },
                new Field()
                {
                    FieldName = "Date",
                    DataType = DataType.Date,
                },
                new Field()
                {
                    FieldName = "Quota",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Leads",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Hot Leads",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "New Seats",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "New Sales",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Renewal Seats",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Renewal Sales ",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Employee",
                },
                new Field()
                {
                    FieldName = "Pipepline",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Forecasted",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Revenue",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Total Opportunites",
                    DataType = DataType.Number,
                },
                new Field()
                {
                    FieldName = "Product",
                },
                new Field()
                {
                    FieldName = "b",
                },
                new Field()
                {
                    FieldName = "c",
                },
                new Field()
                {
                    FieldName = "d",
                },
                new Field()
                {
                    FieldName = "e",
                },
                new Field()
                {
                    FieldName = "f",
                }
            };

            return fields;
        }
    }
}
