# Generate Table of Contents for Reveal.Sdk.Dom Documentation
# This script scans the docs folder and generates a comprehensive TOC

param(
    [string]$DocsPath = "../docs",
    [string]$OutputFile = "../docs/TABLE_OF_CONTENTS.md",
    [switch]$OpenInVSCode
)

function Get-MarkdownTitle {
    param([string]$FilePath)
    
    if (Test-Path $FilePath) {
        $content = Get-Content $FilePath -First 10
        foreach ($line in $content) {
            if ($line -match '^#\s+(.+)$') {
                return $matches[1].Trim()
            }
        }
    }
    return [System.IO.Path]::GetFileNameWithoutExtension($FilePath)
}

function Get-RelativePath {
    param([string]$From, [string]$To)
    
    $fromUri = New-Object System.Uri($From)
    $toUri = New-Object System.Uri($To)
    return $fromUri.MakeRelativeUri($toUri).ToString()
}

function Generate-TOC {
    param([string]$BasePath)
    
    $toc = @()
    $toc += "# Reveal.Sdk.Dom Documentation - Table of Contents"
    $toc += ""
    $toc += "*Generated on: $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')*"
    $toc += ""
    $toc += "## Quick Navigation"
    $toc += ""
    
    # Main sections
    $sections = @(
        @{ Name = "Getting Started"; Path = "getting-started"; Icon = "🚀" }
        @{ Name = "Core Concepts"; Path = "core-concepts"; Icon = "📚" }
        @{ Name = "How-To Guides"; Path = "how-to"; Icon = "📖" }
        @{ Name = "API Reference"; Path = "api-reference"; Icon = "📋" }
        @{ Name = "Examples"; Path = "examples"; Icon = "💡" }
        @{ Name = "Additional Resources"; Path = ""; Icon = "📄" }
    )
    
    foreach ($section in $sections) {
        $toc += "- [$($section.Icon) $($section.Name)](#$($section.Name.ToLower().Replace(' ', '-')))"
    }
    
    $toc += ""
    $toc += "---"
    $toc += ""
    
    # Getting Started
    $toc += "## 🚀 Getting Started"
    $toc += ""
    $gettingStartedPath = Join-Path $BasePath "getting-started"
    if (Test-Path $gettingStartedPath) {
        $files = Get-ChildItem $gettingStartedPath -Filter "*.md" | Sort-Object Name
        foreach ($file in $files) {
            $title = Get-MarkdownTitle $file.FullName
            $relativePath = Get-RelativePath (Join-Path $BasePath "TABLE_OF_CONTENTS.md") $file.FullName
            $toc += "- [$title]($relativePath)"
        }
    }
    $toc += ""
    
    # Core Concepts
    $toc += "## 📚 Core Concepts"
    $toc += ""
    $coreConceptsPath = Join-Path $BasePath "core-concepts"
    if (Test-Path $coreConceptsPath) {
        # Specific order for core concepts
        $orderedFiles = @(
            "rdash-document.md",
            "types-and-enums.md",
            "data-sources.md",
            "visualizations.md",
            "filters.md",
            "variables.md",
            "document-structure.md"
        )
        
        foreach ($fileName in $orderedFiles) {
            $filePath = Join-Path $coreConceptsPath $fileName
            if (Test-Path $filePath) {
                $title = Get-MarkdownTitle $filePath
                $relativePath = Get-RelativePath (Join-Path $BasePath "TABLE_OF_CONTENTS.md") $filePath
                $toc += "- [$title]($relativePath)"
            }
        }
        
        # Add any additional files not in the ordered list
        $allFiles = Get-ChildItem $coreConceptsPath -Filter "*.md"
        foreach ($file in $allFiles) {
            if ($file.Name -notin $orderedFiles) {
                $title = Get-MarkdownTitle $file.FullName
                $relativePath = Get-RelativePath (Join-Path $BasePath "TABLE_OF_CONTENTS.md") $file.FullName
                $toc += "- [$title]($relativePath)"
            }
        }
    }
    $toc += ""
    
    # How-To Guides
    $toc += "## 📖 How-To Guides"
    $toc += ""
    $howToPath = Join-Path $BasePath "how-to"
    if (Test-Path $howToPath) {
        # Data Sources
        $dataSourcesPath = Join-Path $howToPath "data-sources"
        if (Test-Path $dataSourcesPath) {
            $toc += "### 🔌 Data Sources"
            $files = Get-ChildItem $dataSourcesPath -Filter "*.md" | Sort-Object Name
            foreach ($file in $files) {
                $title = Get-MarkdownTitle $file.FullName
                $relativePath = Get-RelativePath (Join-Path $BasePath "TABLE_OF_CONTENTS.md") $file.FullName
                $toc += "- [$title]($relativePath)"
            }
            $toc += ""
        }
        
        # Visualizations
        $visualizationsPath = Join-Path $howToPath "visualizations"
        if (Test-Path $visualizationsPath) {
            $toc += "### 📊 Visualizations"
            $files = Get-ChildItem $visualizationsPath -Filter "*.md" | Sort-Object Name
            foreach ($file in $files) {
                $title = Get-MarkdownTitle $file.FullName
                $relativePath = Get-RelativePath (Join-Path $BasePath "TABLE_OF_CONTENTS.md") $file.FullName
                $toc += "- [$title]($relativePath)"
            }
            $toc += ""
        }
        
        # Root level how-to files
        $files = Get-ChildItem $howToPath -Filter "*.md" | Sort-Object Name
        if ($files.Count -gt 0) {
            $toc += "### 🏢 Enterprise & Advanced"
            foreach ($file in $files) {
                $title = Get-MarkdownTitle $file.FullName
                $relativePath = Get-RelativePath (Join-Path $BasePath "TABLE_OF_CONTENTS.md") $file.FullName
                $toc += "- [$title]($relativePath)"
            }
            $toc += ""
        }
    }
    
    # API Reference
    $toc += "## 📋 API Reference"
    $toc += ""
    $apiRefPath = Join-Path $BasePath "api-reference"
    if (Test-Path $apiRefPath) {
        # Data Sources Reference
        $dataSourcesRefPath = Join-Path $apiRefPath "data-sources"
        if (Test-Path $dataSourcesRefPath) {
            $toc += "### Data Sources"
            $readmePath = Join-Path $dataSourcesRefPath "README.md"
            if (Test-Path $readmePath) {
                $title = Get-MarkdownTitle $readmePath
                $relativePath = Get-RelativePath (Join-Path $BasePath "TABLE_OF_CONTENTS.md") $readmePath
                $toc += "- [$title]($relativePath)"
            }
            $toc += ""
        }
        
        # Visualizations Reference
        $visualizationsRefPath = Join-Path $apiRefPath "visualizations"
        if (Test-Path $visualizationsRefPath) {
            $toc += "### Visualizations"
            $readmePath = Join-Path $visualizationsRefPath "README.md"
            if (Test-Path $readmePath) {
                $title = Get-MarkdownTitle $readmePath
                $relativePath = Get-RelativePath (Join-Path $BasePath "TABLE_OF_CONTENTS.md") $readmePath
                $toc += "- [$title]($relativePath)"
            }
            $toc += ""
        }
    }
    
    # Examples
    $toc += "## 💡 Examples"
    $toc += ""
    $examplesPath = Join-Path $BasePath "examples"
    if (Test-Path $examplesPath) {
        $files = Get-ChildItem $examplesPath -Filter "*.md" | Sort-Object Name
        foreach ($file in $files) {
            $title = Get-MarkdownTitle $file.FullName
            $relativePath = Get-RelativePath (Join-Path $BasePath "TABLE_OF_CONTENTS.md") $file.FullName
            $toc += "- [$title]($relativePath)"
        }
    }
    $toc += ""
    
    # Additional Resources
    $toc += "## 📄 Additional Resources"
    $toc += ""
    $additionalFiles = @(
        "best-practices.md",
        "troubleshooting.md", 
        "faq.md",
        "glossary.md"
    )
    
    foreach ($fileName in $additionalFiles) {
        $filePath = Join-Path $BasePath $fileName
        if (Test-Path $filePath) {
            $title = Get-MarkdownTitle $filePath
            $relativePath = Get-RelativePath (Join-Path $BasePath "TABLE_OF_CONTENTS.md") $filePath
            $toc += "- [$title]($relativePath)"
        }
    }
    
    $toc += ""
    $toc += "---"
    $toc += ""
    $toc += "## 📈 Documentation Statistics"
    $toc += ""
    
    # Calculate statistics
    $allMdFiles = Get-ChildItem $BasePath -Filter "*.md" -Recurse
    $totalFiles = $allMdFiles.Count
    $totalLines = 0
    $totalWords = 0
    
    foreach ($file in $allMdFiles) {
        $content = Get-Content $file.FullName -Raw
        $lines = ($content -split "`n").Count
        $words = ($content -split '\s+').Count
        $totalLines += $lines
        $totalWords += $words
    }
    
    $toc += "- **Total Documentation Files**: $totalFiles"
    $toc += "- **Total Lines**: $($totalLines.ToString('N0'))"
    $toc += "- **Estimated Total Words**: $($totalWords.ToString('N0'))"
    $toc += "- **Last Updated**: $(Get-Date -Format 'yyyy-MM-dd')"
    $toc += ""
    $toc += "*This TOC was automatically generated. To regenerate, run: ``scripts/generate-toc.ps1``*"
    
    return $toc
}

# Main execution
$fullDocsPath = Resolve-Path $DocsPath
$fullOutputPath = Resolve-Path (Split-Path $OutputFile) 
$outputFileName = Split-Path $OutputFile -Leaf
$fullOutputFile = Join-Path $fullOutputPath $outputFileName

Write-Host "Generating Table of Contents..." -ForegroundColor Green
Write-Host "Docs Path: $fullDocsPath" -ForegroundColor Gray
Write-Host "Output File: $fullOutputFile" -ForegroundColor Gray

$toc = Generate-TOC $fullDocsPath
$toc | Out-File -FilePath $fullOutputFile -Encoding UTF8

Write-Host "Table of Contents generated successfully!" -ForegroundColor Green
Write-Host "File saved to: $fullOutputFile" -ForegroundColor Yellow

if ($OpenInVSCode) {
    Write-Host "Opening in VS Code..." -ForegroundColor Blue
    code $fullOutputFile
}