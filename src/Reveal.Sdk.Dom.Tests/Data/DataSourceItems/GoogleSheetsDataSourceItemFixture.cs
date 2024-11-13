using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Data;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data.DataSourceItems
{
    public class GoogleSheetsDataSourceItemFixture
    {
        [Fact]
        public void Constructor_SetsTitleAndDatasource_AsProvided()
        {
            // Arrange
            var dataSource = new GoogleSheetsDataSource();
            var title = "Test title";

            // Act
            var dataSourceItem = new GoogleSheetsDataSourceItem(title, dataSource);

            // Assert
            Assert.Equal(title, dataSourceItem.Title);
            Assert.Equal(dataSource, dataSourceItem.DataSource);
        }

        [Fact]
        public void FirstRowContainsLabels_SaveValueAndProperties_WhenSet()
        {
            // Arrange
            var dataSource = new GoogleSheetsDataSource();
            var dataSourceItem = new GoogleSheetsDataSourceItem("Test", dataSource);

            // Act 1
            dataSourceItem.FirstRowContainsLabels = true;

            // Assert
            Assert.True(dataSourceItem.FirstRowContainsLabels);
            Assert.True(dataSourceItem.Properties.GetValue<bool>("FirstRowContainsLabels"));

            // Act 1
            dataSourceItem.FirstRowContainsLabels = false;

            // Assert
            Assert.False(dataSourceItem.FirstRowContainsLabels);
            Assert.False(dataSourceItem.Properties.GetValue<bool>("FirstRowContainsLabels"));
        }

        [Fact]
        public void NamedRange_SaveValueAndProperties_WhenSet()
        {
            // Arrange
            var dataSource = new GoogleSheetsDataSource();
            var dataSourceItem = new GoogleSheetsDataSourceItem("Test", dataSource);
            var namedRange = "NamedRangeTest";

            // Act
            dataSourceItem.NamedRange = namedRange;

            // Assert
            Assert.Equal(namedRange, dataSourceItem.NamedRange);
            Assert.Equal(namedRange, dataSourceItem.Properties.GetValue<string>("NamedRange"));
        }

        [Fact]
        public void PivotTable_SaveValueAndProperties_WhenSet()
        {
            // Arrange
            var dataSource = new GoogleSheetsDataSource();
            var dataSourceItem = new GoogleSheetsDataSourceItem("Test", dataSource);
            var pivotTable = "PivotTableTest";

            // Act
            dataSourceItem.PivotTable = pivotTable;

            // Assert
            Assert.Equal(pivotTable, dataSourceItem.PivotTable);
            Assert.Equal(pivotTable, dataSourceItem.Properties.GetValue<string>("PivotTable"));
        }

        [Fact]
        public void Sheet_SaveValueAndProperties_WhenSet()
        {
            // Arrange
            var dataSource = new GoogleSheetsDataSource();
            var dataSourceItem = new GoogleSheetsDataSourceItem("Test", dataSource);
            var sheet = "SheetTest";

            // Act
            dataSourceItem.Sheet = sheet;

            // Assert
            Assert.Equal(sheet, dataSourceItem.Sheet);
            Assert.Equal(sheet, dataSourceItem.Properties.GetValue<string>("Sheet"));
        }
    }
}
