# Dashboard Titles vs. Filenames

When working with Reveal dashboards, you often need to distinguish between the dashboard's internal title (stored in the `.rdash` file) and its filename. This is crucial for building dashboard management interfaces, APIs, and user-facing lists.

## Understanding the Difference

- **Filename**: The physical file name on disk (e.g., `Sales_Q4_2023.rdash`)
- **Dashboard Title**: The user-friendly title stored inside the dashboard (e.g., "Q4 2023 Sales Performance")

## Loading Dashboard Titles with DOM

### Basic Title Extraction

The most straightforward way to get a dashboard's title is using `RdashDocument.Load()`:

```csharp
using Reveal.Sdk.Dom;

public string GetDashboardTitle(string filePath)
{
    try
    {
        var document = RdashDocument.Load(filePath);
        return document.Title;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading dashboard {filePath}: {ex.Message}");
        return Path.GetFileNameWithoutExtension(filePath); // Fallback to filename
    }
}
```

### Building Dashboard Lists for APIs

Here's a complete example based on real-world patterns for creating dashboard management APIs:

```csharp
using Reveal.Sdk.Dom;
using System.Text.Json;

public class DashboardService
{
    private readonly string _dashboardsPath;

    public DashboardService()
    {
        _dashboardsPath = Path.Combine(Directory.GetCurrentDirectory(), "Dashboards");
    }

    public List<DashboardInfo> GetDashboardList()
    {
        if (!Directory.Exists(_dashboardsPath))
        {
            return new List<DashboardInfo>();
        }

        var files = Directory.GetFiles(_dashboardsPath, "*.rdash");

        var dashboardList = files.Select(file =>
        {
            try
            {
                var document = RdashDocument.Load(file);
                return new DashboardInfo
                {
                    FileName = Path.GetFileNameWithoutExtension(file),
                    FullPath = file,
                    Title = document.Title,
                    Description = document.Description,
                    Theme = document.Theme.ToString(),
                    VisualizationCount = document.Visualizations.Count,
                    LastModified = File.GetLastWriteTime(file)
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading dashboard {file}: {ex.Message}");
                return new DashboardInfo
                {
                    FileName = Path.GetFileNameWithoutExtension(file),
                    FullPath = file,
                    Title = Path.GetFileNameWithoutExtension(file), // Fallback
                    Description = "Unable to load dashboard metadata",
                    HasError = true,
                    ErrorMessage = ex.Message
                };
            }
        })
        .Where(info => info != null)
        .OrderBy(info => info.Title)
        .ToList();

        return dashboardList;
    }
}

public class DashboardInfo
{
    public string FileName { get; set; } = string.Empty;
    public string FullPath { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Theme { get; set; } = string.Empty;
    public int VisualizationCount { get; set; }
    public DateTime LastModified { get; set; }
    public bool HasError { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}
```

### ASP.NET Core API Endpoint

Creating a RESTful endpoint for dashboard listings:

```csharp
// In your Program.cs or Controller
app.MapGet("/api/dashboards", (DashboardService dashboardService) =>
{
    try
    {
        var dashboards = dashboardService.GetDashboardList();
        return Results.Ok(dashboards);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error retrieving dashboards: {ex.Message}");
        return Results.Problem("An error occurred while retrieving dashboards.");
    }
})
.Produces<IEnumerable<DashboardInfo>>(StatusCodes.Status200OK)
.ProducesProblem(StatusCodes.Status500InternalServerError);

// Specific dashboard by filename
app.MapGet("/api/dashboards/{fileName}", (string fileName, DashboardService dashboardService) =>
{
    try
    {
        var filePath = Path.Combine("Dashboards", $"{fileName}.rdash");
        if (!File.Exists(filePath))
        {
            return Results.NotFound($"Dashboard '{fileName}' not found.");
        }

        var document = RdashDocument.Load(filePath);
        var info = new DashboardInfo
        {
            FileName = fileName,
            Title = document.Title,
            Description = document.Description,
            Theme = document.Theme.ToString(),
            VisualizationCount = document.Visualizations.Count
        };

        return Results.Ok(info);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error loading dashboard: {ex.Message}");
    }
});
```

## Dynamic Dashboard Generation

When generating dashboards programmatically, you can control both the filename and title:

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;

public class DynamicDashboardGenerator
{
    public (string DashboardId, string FileName, string Title) CreateUserDashboard(
        string userId, 
        string friendlyName, 
        string description)
    {
        // Create dashboard with user-friendly title
        var document = new RdashDocument(friendlyName)
        {
            Description = description,
            Theme = Theme.MountainLight
        };

        // Add sample visualization
        var dataSource = new MicrosoftSqlServerDataSource()
        {
            Title = "User Database",
            Host = "localhost",
            Database = "UserDB"
        };

        var dataSourceItem = new MicrosoftSqlServerDataSourceItem("User Data", "Users", dataSource);

        var gridVisualization = new GridVisualization($"{friendlyName} Grid", dataSourceItem)
        {
            Title = $"{friendlyName} - Data Grid"
        };

        document.Visualizations.Add(gridVisualization);

        // Save with systematic filename
        var fileName = $"user_{userId}_{DateTime.Now:yyyyMMdd}";
        var filePath = Path.Combine("Dashboards", $"{fileName}.rdash");
        
        // Ensure directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
        
        document.Save(filePath);

        return (userId, fileName, friendlyName);
    }
}
```

## Client-Side Dashboard Selection

For front-end applications, create dropdown lists showing titles while using filenames for loading:

### JavaScript/HTML Example

```html
<select id="dashboardSelect">
    <option value="">Loading dashboards...</option>
</select>
```

```javascript
async function loadDashboardNames() {
    try {
        const response = await fetch('/api/dashboards');
        const dashboards = await response.json();
        
        const select = document.getElementById('dashboardSelect');
        select.innerHTML = '';
        
        dashboards.forEach(dashboard => {
            const option = document.createElement('option');
            option.value = dashboard.fileName;  // Use filename for loading
            option.textContent = dashboard.title; // Display user-friendly title
            option.title = dashboard.description; // Tooltip with description
            select.appendChild(option);
        });
        
        // Handle selection
        select.addEventListener('change', function() {
            if (this.value) {
                loadDashboard(this.value); // Load by filename
            }
        });
    } catch (error) {
        console.error('Error loading dashboards:', error);
    }
}

function loadDashboard(fileName) {
    // Load dashboard using Reveal SDK
    $.ig.RVDashboard.loadDashboard(fileName)
        .then(dashboard => {
            const revealView = new $.ig.RevealView("#revealView");
            revealView.dashboard = dashboard;
        })
        .catch(error => {
            console.error('Error loading dashboard:', error);
        });
}
```

## Best Practices

### 1. Error Handling
Always handle cases where dashboards might be corrupted or inaccessible:

```csharp
public DashboardInfo GetDashboardInfoSafely(string filePath)
{
    var fileName = Path.GetFileNameWithoutExtension(filePath);
    
    try
    {
        var document = RdashDocument.Load(filePath);
        return new DashboardInfo
        {
            FileName = fileName,
            Title = document.Title ?? fileName, // Fallback if title is null
            Description = document.Description ?? "No description available",
            IsValid = true
        };
    }
    catch (FileNotFoundException)
    {
        return CreateErrorInfo(fileName, "Dashboard file not found");
    }
    catch (UnauthorizedAccessException)
    {
        return CreateErrorInfo(fileName, "Access denied to dashboard file");
    }
    catch (Exception ex)
    {
        return CreateErrorInfo(fileName, $"Unable to load dashboard: {ex.Message}");
    }
}

private static DashboardInfo CreateErrorInfo(string fileName, string error)
{
    return new DashboardInfo
    {
        FileName = fileName,
        Title = fileName,
        Description = error,
        IsValid = false,
        ErrorMessage = error
    };
}
```

### 2. Caching for Performance
For high-traffic applications, cache dashboard metadata:

```csharp
using Microsoft.Extensions.Caching.Memory;

public class CachedDashboardService
{
    private readonly IMemoryCache _cache;
    private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);

    public CachedDashboardService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public DashboardInfo GetDashboardInfo(string filePath)
    {
        var cacheKey = $"dashboard_info_{filePath}";
        
        if (_cache.TryGetValue(cacheKey, out DashboardInfo cachedInfo))
        {
            return cachedInfo;
        }

        var info = LoadDashboardInfoFromFile(filePath);
        
        _cache.Set(cacheKey, info, _cacheExpiration);
        
        return info;
    }
}
```

### 3. Filename Conventions
Establish consistent naming patterns:

```csharp
public static class DashboardNamingConventions
{
    public static string CreateFileName(string userId, string category, string name)
    {
        // Remove invalid characters and create systematic name
        var safeName = string.Join("_", name.Split(Path.GetInvalidFileNameChars()))
                           .Replace(" ", "_")
                           .ToLowerInvariant();
        
        return $"{category}_{userId}_{safeName}_{DateTime.Now:yyyyMMdd}";
    }
    
    public static string ParseUserIdFromFileName(string fileName)
    {
        // Extract user ID from systematic filename
        var parts = fileName.Split('_');
        return parts.Length >= 2 ? parts[1] : string.Empty;
    }
}
```

## Troubleshooting

### Common Issues and Solutions

1. **Empty or Null Titles**: Always provide fallbacks to filenames
2. **File Access Permissions**: Implement proper error handling for access denied scenarios
3. **Corrupted Files**: Use try-catch blocks and validate file integrity
4. **Special Characters**: Sanitize filenames while preserving user-friendly titles
5. **Performance with Many Files**: Implement caching and consider pagination for large dashboard collections

This approach ensures robust dashboard management while providing excellent user experience through meaningful titles and reliable file-based operations.