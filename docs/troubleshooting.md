# Troubleshooting Guide

Solutions to common issues when working with Reveal.Sdk.Dom.

## Installation Issues

### Package Not Found

**Problem**: NuGet cannot find the Reveal.Sdk.Dom package.

**Solution**:
1. Ensure you're using the correct package source (nuget.org)
2. Check your NuGet configuration:
```bash
dotnet nuget list source
```
3. Add nuget.org if missing:
```bash
dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
```

### Version Conflicts

**Problem**: Newtonsoft.Json version conflict.

**Solution**: Update Newtonsoft.Json to version 13.0.3 or higher:
```bash
dotnet add package Newtonsoft.Json --version 13.0.3
```

### Target Framework Mismatch

**Problem**: Package doesn't support your target framework.

**Solution**: Ensure your project targets one of these:
- .NET Framework 4.6.2+
- .NET 6.0+
- .NET 7.0+
- .NET 8.0+
- .NET 9.0+

Update your `.csproj`:
```xml
<PropertyGroup>
  <TargetFramework>net8.0</TargetFramework>
</PropertyGroup>
```

## Dashboard Loading Issues

### File Not Found

**Problem**: `RdashDocument.Load()` throws FileNotFoundException.

**Solution**:
```csharp
// Use absolute path
var filePath = Path.Combine(
    Directory.GetCurrentDirectory(), 
    "dashboard.rdash"
);

if (!File.Exists(filePath))
{
    Console.WriteLine($"File not found: {filePath}");
    return;
}

var document = RdashDocument.Load(filePath);
```

### Invalid JSON Format

**Problem**: Dashboard file won't load due to JSON errors.

**Solution**:
1. Ensure the file wasn't manually edited
2. Validate JSON structure:
```bash
# On Linux/Mac
cat dashboard.rdash | python -m json.tool

# On Windows with PowerShell
Get-Content dashboard.rdash | ConvertFrom-Json
```
3. If corrupted, recreate the dashboard

### Version Compatibility

**Problem**: Dashboard created with newer version won't load.

**Solution**: Use the same version of Reveal.Sdk.Dom for creation and loading:
```bash
# Check current version
dotnet list package | grep Reveal.Sdk.Dom

# Update to specific version
dotnet add package Reveal.Sdk.Dom --version 1.x.x
```

## Data Source Issues

### Fields Not Appearing

**Problem**: No fields showing up in visualization.

**Solution**: For REST APIs, Excel, JSON, and CSV, you must define fields:
```csharp
var apiData = new RestDataSourceItem("Data", restSource);

// Required - define all fields
apiData.Fields.Add(new TextField("Name"));
apiData.Fields.Add(new NumberField("Value"));
apiData.Fields.Add(new DateField("Date"));
```

For SQL databases, fields are auto-discovered:
```csharp
var sqlData = new TableDataSourceItem("Sales", sqlSource)
{
    Table = "Sales"  // Fields come from database schema
};
```

### Cannot Connect to Database

**Problem**: Dashboard won't connect to SQL Server.

**Solution**:
1. Authentication is configured in Reveal SDK at runtime, not in Reveal.Sdk.Dom
2. The `.rdash` file only defines the connection parameters
3. Check:
   - Server address is correct
   - Database name is correct
   - Firewall allows connection
   - Credentials are configured in Reveal SDK

```csharp
// Reveal.Sdk.Dom - just define connection
var ds = new MicrosoftSqlServerDataSource
{
    Host = "server.database.windows.net",
    Database = "SalesDB"
};

// Authentication configured in Reveal SDK:
// RVDashboard.LoadFromJsonAsync(json, credentials);
```

### REST API Not Working

**Problem**: REST data source returns no data.

**Solution**:
1. Verify URL is correct and accessible:
```csharp
var restSource = new RestDataSource
{
    Url = "https://api.example.com/v1/data",  // Full URL
    Title = "API Data"
};
```

2. Define all expected fields:
```csharp
var apiData = new RestDataSourceItem("Data", restSource);
apiData.Fields.Add(new TextField("id"));
apiData.Fields.Add(new TextField("name"));
apiData.Fields.Add(new NumberField("value"));
```

3. Test API separately:
```bash
curl https://api.example.com/v1/data
```

### Excel File Not Found

**Problem**: Excel file path is incorrect.

**Solution**: Use absolute paths:
```csharp
var excelData = new ExcelDataSourceItem("Sales", excelSource)
{
    ResourcePath = Path.Combine(
        Environment.CurrentDirectory,
        "Data",
        "Sales.xlsx"
    ),
    Sheet = "Sheet1"
};

// Verify file exists
if (!File.Exists(excelData.ResourcePath))
{
    throw new FileNotFoundException(
        "Excel file not found", 
        excelData.ResourcePath
    );
}
```

## Visualization Issues

### Visualization Not Showing

**Problem**: Visualization added but not appearing.

**Solution**: Ensure data source item is properly configured:
```csharp
// Check data source item exists
if (dataSourceItem == null)
{
    throw new ArgumentNullException(nameof(dataSourceItem));
}

// Create visualization
var chart = new BarChartVisualization("Sales", dataSourceItem);

// Configure required fields
chart.Labels.Add(new DimensionDataField("Region"));
chart.Values.Add(new MeasureDataField("Sales") 
{ 
    Aggregation = AggregationType.Sum 
});

// Add to document
document.Visualizations.Add(chart);
```

### Visualizations Overlapping

**Problem**: Visualizations overlap each other.

**Solution 1**: Use auto layout (recommended):
```csharp
document.UseAutoLayout = true;
```

**Solution 2**: Set positions manually:
```csharp
document.UseAutoLayout = false;

// First visualization
var chart1 = new BarChartVisualization("Chart 1", data);
chart1.Column = 0;      // Left side
chart1.Row = 0;         // Top
chart1.ColumnSpan = 6;  // Half width
chart1.RowSpan = 4;     // 4 rows high

// Second visualization
var chart2 = new LineChartVisualization("Chart 2", data);
chart2.Column = 6;      // Right side
chart2.Row = 0;         // Top
chart2.ColumnSpan = 6;  // Half width
chart2.RowSpan = 4;     // 4 rows high
```

### Wrong Aggregation Type

**Problem**: Numbers showing incorrectly (e.g., sum instead of average).

**Solution**: Set correct aggregation:
```csharp
// For totals
var totalSales = new MeasureDataField("Sales")
{
    Aggregation = AggregationType.Sum
};

// For averages
var avgPrice = new MeasureDataField("Price")
{
    Aggregation = AggregationType.Average
};

// For counts
var orderCount = new MeasureDataField("OrderID")
{
    Aggregation = AggregationType.Count
};
```

### Chart Showing No Data

**Problem**: Chart renders but shows "No Data".

**Solution**:
1. Verify field names match data source:
```csharp
// Check field names are correct
chart.Labels.Add(new DimensionDataField("Region"));  // Must match data
chart.Values.Add(new MeasureDataField("Sales"));     // Must match data
```

2. Ensure data source has data:
```csharp
// For REST APIs, test endpoint returns data
// For SQL, verify table has records
// For Excel, check sheet has data
```

3. Check filters aren't excluding all data

## Filter Issues

### Filter Not Working

**Problem**: Dashboard filter doesn't affect visualizations.

**Solution**: Ensure visualization uses matching field:
```csharp
// Create filter
var dateFilter = new DashboardDateFilter("Date Range");
document.Filters.Add(dateFilter);

// Visualization must use a date field
var chart = new LineChartVisualization("Sales Trend", data);
chart.Labels.Add(new DateDataField("OrderDate"));  // Connects to date filter
chart.Values.Add(new MeasureDataField("Sales"));
```

### Cannot Remove Filter

**Problem**: Filter persists after removal attempt.

**Solution**:
```csharp
// Remove by reference
var filter = document.Filters.FirstOrDefault(f => f.Title == "Date Range");
if (filter != null)
{
    document.Filters.Remove(filter);
}

// Or clear all
document.Filters.Clear();
```

## Saving Issues

### Access Denied

**Problem**: Cannot save dashboard file.

**Solution**:
```csharp
try
{
    var directory = Path.GetDirectoryName(filePath);
    
    // Create directory if it doesn't exist
    if (!Directory.Exists(directory))
    {
        Directory.CreateDirectory(directory);
    }
    
    // Check write permissions
    if (!HasWriteAccess(directory))
    {
        Console.WriteLine("No write access to directory");
        return;
    }
    
    document.Save(filePath);
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine($"Access denied: {filePath}");
    // Try alternate location
    var altPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "dashboard.rdash"
    );
    document.Save(altPath);
}

bool HasWriteAccess(string directory)
{
    try
    {
        var testFile = Path.Combine(directory, Path.GetRandomFileName());
        File.WriteAllText(testFile, "test");
        File.Delete(testFile);
        return true;
    }
    catch
    {
        return false;
    }
}
```

### File In Use

**Problem**: File is locked by another process.

**Solution**:
```csharp
// Save to temporary file first
var tempFile = Path.GetTempFileName();
document.Save(tempFile);

// Then replace original
try
{
    if (File.Exists(targetFile))
    {
        File.Delete(targetFile);
    }
    File.Move(tempFile, targetFile);
}
catch (IOException)
{
    Console.WriteLine("File is in use. Saved to: " + tempFile);
}
```

## Performance Issues

### Slow Dashboard Creation

**Problem**: Dashboard takes long time to create.

**Solution**:
1. Reuse data source definitions:
```csharp
// Bad - creates new each time
for (int i = 0; i < 10; i++)
{
    var ds = new MicrosoftSqlServerDataSource { ... };
    var item = new TableDataSourceItem($"Table{i}", ds);
}

// Good - reuse data source
var ds = new MicrosoftSqlServerDataSource { ... };
for (int i = 0; i < 10; i++)
{
    var item = new TableDataSourceItem($"Table{i}", ds);
}
```

2. Batch operations:
```csharp
// Create all visualizations first
var visualizations = new List<Visualization>
{
    CreateChart1(),
    CreateChart2(),
    CreateChart3()
};

// Add all at once
visualizations.ForEach(v => document.Visualizations.Add(v));
```

### Large File Size

**Problem**: .rdash file is very large.

**Solution**:
1. Reduce number of visualizations (aim for 10-15)
2. Split into multiple dashboards
3. Simplify data source configurations

## Runtime Errors

### NullReferenceException

**Problem**: Null reference error when creating visualizations.

**Solution**: Always validate:
```csharp
public Visualization CreateChart(DataSourceItem dataSourceItem)
{
    if (dataSourceItem == null)
        throw new ArgumentNullException(nameof(dataSourceItem));
    
    var chart = new BarChartVisualization("Chart", dataSourceItem);
    
    // Validate fields exist
    var labelField = new DimensionDataField("Region");
    if (labelField != null)
    {
        chart.Labels.Add(labelField);
    }
    
    return chart;
}
```

### InvalidOperationException

**Problem**: Invalid operation when modifying dashboard.

**Solution**: Check object state before operations:
```csharp
// Check collection before accessing
if (document.Visualizations.Count > 0)
{
    var firstViz = document.Visualizations[0];
}

// Check for null before using
if (document.Title != null)
{
    Console.WriteLine(document.Title);
}
```

## Integration Issues

### Cannot Load in Reveal SDK

**Problem**: Dashboard created with Reveal.Sdk.Dom won't load in Reveal SDK.

**Solution**:
1. Export to JSON correctly:
```csharp
var json = document.ToJsonString();

// Load in Reveal SDK
var dashboard = await RVDashboard.LoadFromJsonAsync(json);
revealView.Dashboard = dashboard;
```

2. Ensure versions are compatible:
   - Reveal.Sdk.Dom version should match Reveal SDK version

3. Check for validation errors before exporting

### Authentication Not Working

**Problem**: Cannot authenticate with data sources.

**Solution**: Authentication is configured in Reveal SDK, not Reveal.Sdk.Dom:

```csharp
// In Reveal SDK, implement IRVAuthenticationProvider
public class AuthProvider : IRVAuthenticationProvider
{
    public Task<IRVDataSourceCredential> ResolveCredentialsAsync(
        RVDashboardDataSource dataSource)
    {
        if (dataSource is RVSqlServerDataSource sqlDs)
        {
            return Task.FromResult<IRVDataSourceCredential>(
                new RVUsernamePasswordDataSourceCredential(
                    "username", 
                    "password"
                )
            );
        }
        return Task.FromResult<IRVDataSourceCredential>(null);
    }
}

// Configure in Reveal SDK
RevealSdkSettings.AuthenticationProvider = new AuthProvider();
```

## Debugging Tips

### Enable Logging

```csharp
try
{
    var document = new RdashDocument("Debug Dashboard");
    Console.WriteLine("Document created");
    
    var data = CreateDataSource();
    Console.WriteLine("Data source created");
    
    var chart = new BarChartVisualization("Chart", data);
    Console.WriteLine("Visualization created");
    
    document.Visualizations.Add(chart);
    Console.WriteLine($"Visualizations count: {document.Visualizations.Count}");
    
    document.Save("debug.rdash");
    Console.WriteLine("Saved successfully");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Console.WriteLine($"Stack trace: {ex.StackTrace}");
}
```

### Validate Dashboard Structure

```csharp
public void ValidateDashboard(RdashDocument document)
{
    Console.WriteLine($"Title: {document.Title}");
    Console.WriteLine($"Visualizations: {document.Visualizations.Count}");
    Console.WriteLine($"Filters: {document.Filters.Count}");
    Console.WriteLine($"Variables: {document.Variables.Count}");
    
    foreach (var viz in document.Visualizations)
    {
        Console.WriteLine($"  - {viz.Title}");
        Console.WriteLine($"    Type: {viz.GetType().Name}");
        Console.WriteLine($"    Has Data: {viz.DataDefinition?.DataSourceItem != null}");
    }
}
```

### Inspect JSON Output

```csharp
var json = document.ToJsonString(Formatting.Indented);
File.WriteAllText("debug-output.json", json);
Console.WriteLine("JSON saved to debug-output.json");
// Open file and inspect structure
```

## Getting Help

If you're still experiencing issues:

1. **Check documentation**: Review the relevant sections
2. **Search GitHub Issues**: Someone may have had the same issue
3. **Create minimal reproduction**: Simplify code to minimum that shows the issue
4. **Report bug**: Open an issue on [GitHub](https://github.com/RevealBi/Reveal.Sdk.Dom/issues) with:
   - Clear description
   - Code to reproduce
   - Expected vs actual behavior
   - Version information
   - Error messages and stack traces

## Related Topics

- [FAQ](faq.md)
- [Best Practices](best-practices.md)
- [Getting Started](getting-started/quick-start.md)
- [API Reference](api-reference/)
