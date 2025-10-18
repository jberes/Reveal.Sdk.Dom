# Server-Side Dynamic Dashboard Generation

This guide covers advanced patterns for generating dashboards dynamically on the server-side using Reveal.Sdk.Dom, based on real-world enterprise applications. These patterns enable automatic dashboard creation from database schemas, user queries, and business rules.

## Overview

Server-side dashboard generation allows you to:
- Create personalized dashboards based on user roles and data access
- Generate reports from database schemas automatically  
- Build dashboards from user-defined queries
- Implement multi-tenant dashboard provisioning
- Create templated dashboard systems

## Basic Dynamic Generation Pattern

### Query-Based Dashboard Generation

This pattern creates dashboards from user-defined SQL queries:

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System.Text.Json;

public class QueryDashboardGenerator
{
    private readonly string _dashboardsPath;
    private readonly string _queriesPath;

    public QueryDashboardGenerator()
    {
        _dashboardsPath = Path.Combine(Directory.GetCurrentDirectory(), "Dashboards");
        _queriesPath = Path.Combine(Directory.GetCurrentDirectory(), "Queries");
    }

    public async Task<(string DashboardId, string FileName, string Title)> 
        GenerateGridDashboardAsync(string queryId)
    {
        // Validate GUID format
        if (!Guid.TryParse(queryId, out _))
        {
            throw new ArgumentException("Invalid query ID format. Expected a valid GUID.");
        }
        
        // Load query metadata
        var queryMetadata = await LoadQueryMetadataAsync(queryId);
        
        // Create the dashboard document
        var title = queryMetadata.FriendlyName;
        var document = new RdashDocument(title)
        {
            Description = queryMetadata.Description ?? $"Generated from query: {queryMetadata.TableName}",
            Theme = Theme.OceanLight
        };

        // Create data source
        var dataSource = CreateDataSourceFromQuery(queryMetadata);
        
        // Create data source item with proper field mapping
        var dataSourceItem = new DataSourceItem(title, dataSource)
        {
            Id = queryId.ToString(),
            Title = title,
            Subtitle = queryMetadata.Description ?? $"Data from {queryMetadata.TableName}",
            Fields = MapColumnsToRevealFields(queryMetadata.Columns)
        };

        // Create and configure visualization
        var gridVisualization = new GridVisualization("Dynamic Grid", dataSourceItem)
        {
            ColumnSpan = 6,
            RowSpan = 4,
            Description = queryMetadata.Description ?? $"Grid visualization for {queryMetadata.TableName}",
            IsTitleVisible = true,
            Id = queryId.ToString(),
            Title = title
        };

        // Configure grid settings based on data types
        ConfigureGridVisualization(gridVisualization, queryMetadata);
        
        // Add visualization to dashboard
        document.Visualizations.Add(gridVisualization);

        // Save and return dashboard info
        return await SaveDashboardAsync(document, queryId, title);
    }

    private async Task<QueryMetadata> LoadQueryMetadataAsync(string queryId)
    {
        var jsonFilePath = Path.Combine(_queriesPath, $"{queryId}.json");
        
        if (!File.Exists(jsonFilePath))
        {
            throw new FileNotFoundException($"Query with ID '{queryId}' not found.");
        }
        
        var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
        var queryMetadata = JsonSerializer.Deserialize<QueryMetadata>(jsonContent, 
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        
        if (queryMetadata?.Columns == null || queryMetadata.Columns.Length == 0)
        {
            throw new InvalidOperationException("Query metadata is invalid or missing column information.");
        }

        return queryMetadata;
    }

    private DataSource CreateDataSourceFromQuery(QueryMetadata queryMetadata)
    {
        // Create appropriate data source based on query type
        return new PostgreSQLDataSource()
        {
            Title = "Query Data Source",
            Subtitle = $"Generated for {queryMetadata.TableName}"
        };
    }

    private void ConfigureGridVisualization(GridVisualization grid, QueryMetadata queryMetadata)
    {
        grid.ConfigureSettings(settings =>
        {
            settings.FontSize = FontSize.Small;
            settings.PageSize = DetermineOptimalPageSize(queryMetadata.Columns.Length);
            settings.IsPagingEnabled = true;
            settings.IsFirstColumnFixed = true;
            
            // Configure column formatting based on data types
            ConfigureColumnFormatting(settings, queryMetadata.Columns);
        });

        // Set visible columns (all fields from query)
        grid.SetColumns(queryMetadata.Fields);
    }

    private int DetermineOptimalPageSize(int columnCount)
    {
        // Adjust page size based on column count for better performance
        return columnCount switch
        {
            <= 5 => 50,
            <= 10 => 30,
            <= 20 => 20,
            _ => 15
        };
    }

    private void ConfigureColumnFormatting(GridVisualizationSettings settings, ColumnMetadata[] columns)
    {
        foreach (var column in columns)
        {
            switch (column.RevealDataType)
            {
                case "Number":
                    // Configure number formatting
                    settings.SetColumnAlignment(column.ColumnName, TextAlignment.Right);
                    break;
                case "Date":
                    // Configure date formatting
                    settings.SetColumnAlignment(column.ColumnName, TextAlignment.Center);
                    break;
                default:
                    settings.SetColumnAlignment(column.ColumnName, TextAlignment.Left);
                    break;
            }
        }
    }

    private async Task<(string, string, string)> SaveDashboardAsync(RdashDocument document, string queryId, string title)
    {
        if (!Directory.Exists(_dashboardsPath))
        {
            Directory.CreateDirectory(_dashboardsPath);
        }
        
        var dashboardFileName = $"user_{queryId}.rdash";
        var dashboardFilePath = Path.Combine(_dashboardsPath, dashboardFileName);
        
        document.Save(dashboardFilePath);
        
        return ($"user_{queryId}", dashboardFileName, title);
    }
}
```

## Advanced Multi-Visualization Dashboard Generation

### Schema-Based Dashboard Creator

This pattern analyzes database schemas to create comprehensive dashboards automatically:

```csharp
public class SchemaDashboardGenerator
{
    public async Task<RdashDocument> CreateComprehensiveDashboardAsync(
        string connectionString,
        string tableName, 
        DashboardGenerationOptions options)
    {
        // Analyze table structure
        var tableAnalysis = await AnalyzeTableAsync(connectionString, tableName);
        
        // Create dashboard with intelligent layout
        var document = new RdashDocument($"{FormatTableName(tableName)} Analytics")
        {
            Description = $"Comprehensive analysis of {tableName} data",
            Theme = options.Theme ?? Theme.MountainLight
        };

        // Create data source
        var dataSource = new MicrosoftSqlServerDataSource()
        {
            Title = $"{tableName} Database",
            Subtitle = "Auto-generated data source"
        };

        var dataSourceItem = CreateDataSourceItem(tableName, dataSource, tableAnalysis);

        // Generate visualizations based on data analysis
        await GenerateVisualizationsAsync(document, dataSourceItem, tableAnalysis, options);

        return document;
    }

    private async Task<TableAnalysis> AnalyzeTableAsync(string connectionString, string tableName)
    {
        var analysis = new TableAnalysis
        {
            TableName = tableName,
            Columns = await GetColumnInfoAsync(connectionString, tableName),
            SampleData = await GetSampleDataAsync(connectionString, tableName),
            RowCount = await GetRowCountAsync(connectionString, tableName)
        };

        // Analyze column characteristics
        analysis.NumericColumns = analysis.Columns.Where(IsNumericColumn).ToList();
        analysis.DateColumns = analysis.Columns.Where(IsDateColumn).ToList();  
        analysis.CategoricalColumns = analysis.Columns.Where(IsCategoricalColumn).ToList();
        analysis.KeyColumns = analysis.Columns.Where(IsLikelyKeyColumn).ToList();

        return analysis;
    }

    private async Task GenerateVisualizationsAsync(
        RdashDocument document,
        DataSourceItem dataSourceItem, 
        TableAnalysis analysis,
        DashboardGenerationOptions options)
    {
        var layout = new DashboardLayoutManager(6, 12); // 6 columns, up to 12 rows

        // 1. Overview KPIs
        if (analysis.NumericColumns.Count > 0)
        {
            CreateOverviewKPIs(document, dataSourceItem, analysis, layout);
        }

        // 2. Main data grid
        CreateDataGrid(document, dataSourceItem, analysis, layout);

        // 3. Trend analysis (if date columns exist)
        if (analysis.DateColumns.Count > 0 && analysis.NumericColumns.Count > 0)
        {
            CreateTrendCharts(document, dataSourceItem, analysis, layout);
        }

        // 4. Category breakdowns
        if (analysis.CategoricalColumns.Count > 0 && analysis.NumericColumns.Count > 0)
        {
            CreateCategoryCharts(document, dataSourceItem, analysis, layout);
        }

        // 5. Distribution charts
        if (analysis.NumericColumns.Count >= 2)
        {
            CreateDistributionCharts(document, dataSourceItem, analysis, layout);
        }
    }

    private void CreateOverviewKPIs(
        RdashDocument document,
        DataSourceItem dataSourceItem, 
        TableAnalysis analysis,
        DashboardLayoutManager layout)
    {
        // Create KPIs for the first 3 numeric columns
        foreach (var numericCol in analysis.NumericColumns.Take(3))
        {
            var position = layout.GetNextPosition(2, 2);
            
            var kpi = new KpiVisualization($"{numericCol.ColumnName}_KPI", dataSourceItem)
            {
                Title = $"Total {FormatColumnName(numericCol.ColumnName)}",
                ColumnSpan = position.Width,
                RowSpan = position.Height,
                Column = position.Column,
                Row = position.Row
            };

            kpi.SetValue(numericCol.ColumnName, DetermineAggregation(numericCol));
            document.Visualizations.Add(kpi);
        }
    }

    private void CreateDataGrid(
        RdashDocument document,
        DataSourceItem dataSourceItem,
        TableAnalysis analysis, 
        DashboardLayoutManager layout)
    {
        var position = layout.GetNextPosition(6, 3);
        
        var grid = new GridVisualization("MainGrid", dataSourceItem)
        {
            Title = $"{FormatTableName(analysis.TableName)} Data",
            ColumnSpan = position.Width,
            RowSpan = position.Height,
            Column = position.Column,
            Row = position.Row
        };

        // Configure grid with intelligent column selection
        var displayColumns = SelectDisplayColumns(analysis.Columns, 10);
        grid.SetColumns(displayColumns);

        ConfigureGridAppearance(grid, analysis);
        
        document.Visualizations.Add(grid);
    }

    private void CreateTrendCharts(
        RdashDocument document,
        DataSourceItem dataSourceItem,
        TableAnalysis analysis,
        DashboardLayoutManager layout)
    {
        var dateCol = analysis.DateColumns.First();
        
        foreach (var numericCol in analysis.NumericColumns.Take(2))
        {
            var position = layout.GetNextPosition(3, 3);
            
            var lineChart = new LineChartVisualization($"Trend_{numericCol.ColumnName}", dataSourceItem)
            {
                Title = $"{FormatColumnName(numericCol.ColumnName)} Over Time",
                ColumnSpan = position.Width,
                RowSpan = position.Height,
                Column = position.Column,
                Row = position.Row
            };

            lineChart.SetLabel(dateCol.ColumnName);
            lineChart.SetValue(numericCol.ColumnName, DetermineAggregation(numericCol));
            
            document.Visualizations.Add(lineChart);
        }
    }

    private void CreateCategoryCharts(
        RdashDocument document,
        DataSourceItem dataSourceItem,
        TableAnalysis analysis,
        DashboardLayoutManager layout)
    {
        var categoryCol = analysis.CategoricalColumns.First();
        var valueCol = analysis.NumericColumns.First();

        // Pie chart for category distribution
        var position1 = layout.GetNextPosition(3, 3);
        var pieChart = new PieChartVisualization("CategoryPie", dataSourceItem)
        {
            Title = $"{FormatColumnName(valueCol.ColumnName)} by {FormatColumnName(categoryCol.ColumnName)}",
            ColumnSpan = position1.Width,
            RowSpan = position1.Height,
            Column = position1.Column,
            Row = position1.Row
        };

        pieChart.SetLabel(categoryCol.ColumnName);
        pieChart.SetValue(valueCol.ColumnName, DetermineAggregation(valueCol));
        document.Visualizations.Add(pieChart);

        // Bar chart for comparison
        var position2 = layout.GetNextPosition(3, 3);
        var barChart = new BarChartVisualization("CategoryBar", dataSourceItem)
        {
            Title = $"{FormatColumnName(valueCol.ColumnName)} Comparison",
            ColumnSpan = position2.Width,
            RowSpan = position2.Height,
            Column = position2.Column,
            Row = position2.Row
        };

        barChart.SetLabel(categoryCol.ColumnName);
        barChart.SetValue(valueCol.ColumnName, DetermineAggregation(valueCol));
        document.Visualizations.Add(barChart);
    }
}

public class DashboardLayoutManager
{
    private readonly int _maxColumns;
    private readonly int _maxRows;
    private int _currentColumn = 0;
    private int _currentRow = 0;

    public DashboardLayoutManager(int maxColumns, int maxRows)
    {
        _maxColumns = maxColumns;
        _maxRows = maxRows;
    }

    public LayoutPosition GetNextPosition(int requestedWidth, int requestedHeight)
    {
        // Simple layout algorithm - can be enhanced with more sophisticated logic
        if (_currentColumn + requestedWidth > _maxColumns)
        {
            _currentColumn = 0;
            _currentRow += requestedHeight;
        }

        var position = new LayoutPosition
        {
            Column = _currentColumn,
            Row = _currentRow,
            Width = requestedWidth,
            Height = requestedHeight
        };

        _currentColumn += requestedWidth;

        return position;
    }
}

public class LayoutPosition
{
    public int Column { get; set; }
    public int Row { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
}

public class TableAnalysis
{
    public string TableName { get; set; } = string.Empty;
    public List<ColumnInfo> Columns { get; set; } = new();
    public List<ColumnInfo> NumericColumns { get; set; } = new();
    public List<ColumnInfo> DateColumns { get; set; } = new();
    public List<ColumnInfo> CategoricalColumns { get; set; } = new();
    public List<ColumnInfo> KeyColumns { get; set; } = new();
    public Dictionary<string, object[]> SampleData { get; set; } = new();
    public long RowCount { get; set; }
}

public class DashboardGenerationOptions
{
    public Theme? Theme { get; set; }
    public int MaxVisualizations { get; set; } = 10;
    public bool IncludeKPIs { get; set; } = true;
    public bool IncludeTrendCharts { get; set; } = true;
    public bool IncludeCategoryCharts { get; set; } = true;
    public string[] ExcludeColumns { get; set; } = Array.Empty<string>();
}
```

## Enterprise Multi-Tenant Dashboard Generation

### Tenant-Aware Dashboard Factory

For multi-tenant SaaS applications:

```csharp
public class TenantDashboardFactory
{
    private readonly ITenantService _tenantService;
    private readonly IDataAccessService _dataAccessService;
    private readonly IDashboardTemplateService _templateService;

    public TenantDashboardFactory(
        ITenantService tenantService,
        IDataAccessService dataAccessService,
        IDashboardTemplateService templateService)
    {
        _tenantService = tenantService;
        _dataAccessService = dataAccessService;
        _templateService = templateService;
    }

    public async Task<RdashDocument> CreateTenantDashboardAsync(
        string tenantId, 
        string userId, 
        string templateName,
        Dictionary<string, object> parameters = null)
    {
        // Get tenant configuration
        var tenant = await _tenantService.GetTenantAsync(tenantId);
        var userPermissions = await _tenantService.GetUserPermissionsAsync(tenantId, userId);
        
        // Load dashboard template
        var template = await _templateService.GetTemplateAsync(templateName);
        
        // Create personalized dashboard
        var document = new RdashDocument(template.Name)
        {
            Description = $"Personalized dashboard for {tenant.Name}",
            Theme = tenant.Theme ?? Theme.MountainLight
        };

        // Create tenant-specific data sources
        var dataSources = await CreateTenantDataSourcesAsync(tenant, userPermissions);
        
        // Generate visualizations from template
        foreach (var visualizationTemplate in template.Visualizations)
        {
            if (await CanUserAccessVisualization(userId, visualizationTemplate, userPermissions))
            {
                var visualization = await CreateVisualizationFromTemplate(
                    visualizationTemplate, 
                    dataSources, 
                    tenant,
                    parameters);
                    
                if (visualization != null)
                {
                    document.Visualizations.Add(visualization);
                }
            }
        }

        // Apply tenant-specific filters
        ApplyTenantFilters(document, tenant, userPermissions);
        
        return document;
    }

    private async Task<List<DataSource>> CreateTenantDataSourcesAsync(
        TenantInfo tenant, 
        UserPermissions permissions)
    {
        var dataSources = new List<DataSource>();
        
        // Create tenant database connection
        if (permissions.CanAccessTenantData)
        {
            var tenantDb = new MicrosoftSqlServerDataSource()
            {
                Title = $"{tenant.Name} Data",
                Database = tenant.DatabaseName,
                Host = tenant.DatabaseHost
            };
            dataSources.Add(tenantDb);
        }

        // Create shared data sources if permitted
        if (permissions.CanAccessSharedData)
        {
            var sharedDb = new MicrosoftSqlServerDataSource()
            {
                Title = "Shared Analytics",
                Database = "SharedAnalytics",
                Host = "analytics.company.com"
            };
            dataSources.Add(sharedDb);
        }

        return dataSources;
    }

    private void ApplyTenantFilters(RdashDocument document, TenantInfo tenant, UserPermissions permissions)
    {
        // Add tenant isolation filters
        var tenantFilter = new TabularDataFilter("TenantId", tenant.Id);
        document.Filters.Add(tenantFilter);

        // Add user-level filters based on permissions
        if (permissions.UserLevelFilters?.Count > 0)
        {
            foreach (var filter in permissions.UserLevelFilters)
            {
                document.Filters.Add(new TabularDataFilter(filter.FieldName, filter.Value));
            }
        }
    }
}

public interface ITenantService
{
    Task<TenantInfo> GetTenantAsync(string tenantId);
    Task<UserPermissions> GetUserPermissionsAsync(string tenantId, string userId);
}

public class TenantInfo
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string DatabaseHost { get; set; } = string.Empty;
    public Theme Theme { get; set; } = Theme.MountainLight;
}

public class UserPermissions
{
    public bool CanAccessTenantData { get; set; }
    public bool CanAccessSharedData { get; set; }
    public List<UserFilter> UserLevelFilters { get; set; } = new();
}

public class UserFilter
{
    public string FieldName { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
```

## Performance Optimization Patterns

### Cached Dashboard Generation

For high-performance scenarios:

```csharp
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;

public class CachedDashboardGenerator
{
    private readonly IMemoryCache _memoryCache;
    private readonly IDistributedCache _distributedCache;
    private readonly IDashboardGenerator _generator;

    public CachedDashboardGenerator(
        IMemoryCache memoryCache,
        IDistributedCache distributedCache,
        IDashboardGenerator generator)
    {
        _memoryCache = memoryCache;
        _distributedCache = distributedCache;
        _generator = generator;
    }

    public async Task<RdashDocument> GetOrCreateDashboardAsync(
        string cacheKey,
        Func<Task<RdashDocument>> dashboardFactory,
        TimeSpan? cacheExpiration = null)
    {
        var expiration = cacheExpiration ?? TimeSpan.FromMinutes(30);
        
        // Try memory cache first
        if (_memoryCache.TryGetValue(cacheKey, out RdashDocument cachedDashboard))
        {
            return cachedDashboard;
        }

        // Try distributed cache
        var serializedDashboard = await _distributedCache.GetStringAsync(cacheKey);
        if (!string.IsNullOrEmpty(serializedDashboard))
        {
            var dashboard = DeserializeDashboard(serializedDashboard);
            _memoryCache.Set(cacheKey, dashboard, expiration);
            return dashboard;
        }

        // Generate new dashboard
        var newDashboard = await dashboardFactory();
        
        // Cache in both memory and distributed cache
        _memoryCache.Set(cacheKey, newDashboard, expiration);
        
        var serialized = SerializeDashboard(newDashboard);
        await _distributedCache.SetStringAsync(cacheKey, serialized, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiration
        });

        return newDashboard;
    }

    private string SerializeDashboard(RdashDocument dashboard)
    {
        // Serialize dashboard to JSON for caching
        return dashboard.ToJsonString();
    }

    private RdashDocument DeserializeDashboard(string serializedDashboard)
    {
        // Deserialize dashboard from JSON
        return RdashDocument.FromJsonString(serializedDashboard);
    }
}
```

## Best Practices for Server-Side Generation

### 1. Error Handling and Validation

```csharp
public class RobustDashboardGenerator
{
    public async Task<GenerationResult> GenerateDashboardSafelyAsync(GenerationRequest request)
    {
        try
        {
            // Validate input
            ValidateGenerationRequest(request);
            
            // Generate with timeout protection
            var dashboard = await GenerateWithTimeoutAsync(request, TimeSpan.FromMinutes(5));
            
            // Validate output
            ValidateGeneratedDashboard(dashboard);
            
            return GenerationResult.Success(dashboard);
        }
        catch (ValidationException ex)
        {
            return GenerationResult.Failure($"Validation error: {ex.Message}");
        }
        catch (TimeoutException ex)
        {
            return GenerationResult.Failure("Dashboard generation timed out");
        }
        catch (Exception ex)
        {
            // Log error details
            LogGenerationError(request, ex);
            return GenerationResult.Failure("Dashboard generation failed");
        }
    }

    private async Task<RdashDocument> GenerateWithTimeoutAsync(GenerationRequest request, TimeSpan timeout)
    {
        using var cts = new CancellationTokenSource(timeout);
        return await GenerateDashboardAsync(request, cts.Token);
    }
}

public class GenerationResult
{
    public bool IsSuccess { get; set; }
    public RdashDocument Dashboard { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;

    public static GenerationResult Success(RdashDocument dashboard) =>
        new() { IsSuccess = true, Dashboard = dashboard };
        
    public static GenerationResult Failure(string error) =>
        new() { IsSuccess = false, ErrorMessage = error };
}
```

### 2. Resource Management

```csharp
public class ResourceAwareDashboardGenerator : IDisposable
{
    private readonly SemaphoreSlim _concurrencyLimiter;
    private readonly ILogger<ResourceAwareDashboardGenerator> _logger;
    private bool _disposed = false;

    public ResourceAwareDashboardGenerator(ILogger<ResourceAwareDashboardGenerator> logger)
    {
        _concurrencyLimiter = new SemaphoreSlim(Environment.ProcessorCount * 2);
        _logger = logger;
    }

    public async Task<RdashDocument> GenerateDashboardAsync(GenerationRequest request)
    {
        await _concurrencyLimiter.WaitAsync();
        
        try
        {
            using var activity = ActivitySource.StartActivity("DashboardGeneration");
            activity?.SetTag("RequestType", request.Type);
            activity?.SetTag("TenantId", request.TenantId);

            _logger.LogInformation("Starting dashboard generation for {TenantId}", request.TenantId);
            
            var result = await GenerateInternalAsync(request);
            
            _logger.LogInformation("Dashboard generation completed for {TenantId}", request.TenantId);
            
            return result;
        }
        finally
        {
            _concurrencyLimiter.Release();
        }
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _concurrencyLimiter?.Dispose();
            _disposed = true;
        }
    }
}
```

This comprehensive approach to server-side dashboard generation provides the foundation for building scalable, maintainable, and high-performance dashboard systems that can adapt to various enterprise requirements and data sources.