# Documentation Management Scripts

This folder contains scripts to help manage and navigate the Reveal.Sdk.Dom documentation.

## 📋 Table of Contents Generator

### Quick Start

**macOS/Linux:**
```bash
cd scripts
./generate-toc.sh
```

**Windows (PowerShell):**
```powershell
cd scripts
.\generate-toc.ps1
```

### What it does

The TOC generator automatically scans your `docs/` folder and creates a comprehensive table of contents with:

- 🔍 **Smart file discovery** - Finds all markdown files in the documentation structure
- 📂 **Organized sections** - Groups content by Getting Started, Core Concepts, How-To Guides, API Reference, Examples, and Additional Resources
- 🎯 **Logical ordering** - Core concepts are ordered logically (Types & Enums early, etc.)
- 📊 **Documentation statistics** - Shows total files, lines, and words
- 🔗 **Clickable navigation** - All links work correctly in VS Code and GitHub
- 📱 **Quick navigation** - Jump links at the top for fast access

### Generated TOC Features

The generated `TABLE_OF_CONTENTS.md` includes:

```markdown
## Quick Navigation
- 🚀 Getting Started
- 📚 Core Concepts  
- 📖 How-To Guides
- 📋 API Reference
- 💡 Examples
- 📄 Additional Resources

## 📈 Documentation Statistics
- Total Documentation Files: 15
- Total Lines: 3,247
- Estimated Total Words: 24,891
- Last Updated: 2025-10-18
```

### Script Options

**Bash version (`generate-toc.sh`):**
```bash
# Basic usage
./generate-toc.sh

# Custom paths
./generate-toc.sh --docs-path /path/to/docs --output /path/to/output.md

# Open in VS Code after generation
./generate-toc.sh --open
```

**PowerShell version (`generate-toc.ps1`):**
```powershell
# Basic usage
.\generate-toc.ps1

# Custom paths
.\generate-toc.ps1 -DocsPath "C:\path\to\docs" -OutputFile "C:\path\to\output.md"

# Open in VS Code after generation
.\generate-toc.ps1 -OpenInVSCode
```

## 🚀 VS Code Documentation Workspace

### Quick Start

1. **Open the workspace:**
   ```bash
   code Reveal.Sdk.Dom.code-workspace
   ```

2. **Install recommended extensions** (VS Code will prompt you)

3. **View documentation in preview mode:**
   - Open any `.md` file
   - Press `Cmd+Shift+V` (Mac) or `Ctrl+Shift+V` (Windows/Linux)
   - Use `Cmd+K V` (Mac) or `Ctrl+K V` (Windows/Linux) for side-by-side preview

### Workspace Features

The workspace configuration provides:

#### 📖 Enhanced Markdown Preview
- **Better typography** - Improved fonts and spacing
- **Link navigation** - Click links to navigate between docs
- **Math support** - Renders LaTeX equations
- **Mermaid diagrams** - Supports flowcharts and diagrams

#### 🔧 Documentation-Optimized Settings
- **Word wrap** enabled for comfortable reading
- **Minimal UI** - Hides line numbers, minimap for distraction-free writing
- **Auto-save** - Saves changes automatically
- **Spell checking** - Includes Reveal-specific terminology

#### ⚡ Quick Tasks
Access via `Cmd+Shift+P` (Mac) or `Ctrl+Shift+P` (Windows/Linux) → "Tasks: Run Task":

- **Generate Documentation TOC** - Regenerate the table of contents
- **Open Documentation TOC** - Quick access to the TOC
- **Preview Documentation** - Shows keyboard shortcuts for preview mode

#### 🎯 Recommended Extensions
The workspace automatically suggests these extensions:
- **Markdown All in One** - Enhanced markdown editing
- **Markdown Preview Enhanced** - Advanced preview features  
- **Code Spell Checker** - Spell checking with custom dictionary
- **markdownlint** - Markdown style checking
- **Markdown Mermaid** - Diagram support

## 📖 Viewing Documentation in VS Code

### Preview Modes

1. **Side-by-side preview:**
   - Open markdown file
   - Press `Cmd+K V` (Mac) or `Ctrl+K V` (Windows/Linux)
   - Edit and preview simultaneously

2. **Full preview:**
   - Open markdown file
   - Press `Cmd+Shift+V` (Mac) or `Ctrl+Shift+V` (Windows/Linux)
   - View in full preview mode

3. **Quick preview:**
   - Hover over markdown links to see quick previews
   - `Cmd+Click` (Mac) or `Ctrl+Click` (Windows/Linux) to follow links

### Navigation Tips

- **Quick file switching:** `Cmd+P` (Mac) or `Ctrl+P` (Windows/Linux) and type filename
- **Search across docs:** `Cmd+Shift+F` (Mac) or `Ctrl+Shift+F` (Windows/Linux)
- **Outline view:** Use the outline panel to navigate headings
- **Breadcrumbs:** Enable breadcrumbs for location context

### Link Navigation

The workspace is configured so that:
- ✅ **Relative links work** - Navigate between documents with clicks
- ✅ **Auto-complete** - File paths auto-complete when typing links
- ✅ **Link validation** - Broken links are highlighted
- ✅ **Cross-references** - Find all references to a document

## 🔄 Automating TOC Updates

### Git Hooks (Recommended)

Create a pre-commit hook to automatically update the TOC:

```bash
# .git/hooks/pre-commit
#!/bin/sh
cd scripts
./generate-toc.sh
git add ../docs/TABLE_OF_CONTENTS.md
```

### VS Code Tasks

The workspace includes tasks you can run:
1. Open Command Palette (`Cmd+Shift+P` / `Ctrl+Shift+P`)
2. Type "Tasks: Run Task"
3. Select "Generate Documentation TOC"

### CI/CD Integration

Add to your GitHub Actions workflow:

```yaml
- name: Generate Documentation TOC
  run: |
    chmod +x scripts/generate-toc.sh
    cd scripts
    ./generate-toc.sh
    
- name: Commit TOC updates
  run: |
    git config --local user.email "action@github.com"
    git config --local user.name "GitHub Action"
    git add docs/TABLE_OF_CONTENTS.md
    git diff --staged --quiet || git commit -m "Auto-update documentation TOC"
```

## 📂 File Organization

The scripts expect this documentation structure:

```
docs/
├── TABLE_OF_CONTENTS.md      # Generated automatically
├── README.md                 # Main docs entry point
├── getting-started/          # New user guides
├── core-concepts/           # Fundamental concepts
│   └── types-and-enums.md   # Essential reference (prioritized)
├── how-to/                  # Task-oriented guides
│   ├── data-sources/        # Data source guides
│   └── visualizations/      # Visualization guides
├── api-reference/           # Technical reference
├── examples/                # Working examples
├── best-practices.md        # Best practices
├── troubleshooting.md       # Common issues
├── faq.md                  # Frequently asked questions
└── glossary.md             # Terms and definitions
```

## 🛠️ Customization

### Adding New Sections

To add new sections to the TOC generator:

1. **Edit the script** (`generate-toc.sh` or `generate-toc.ps1`)
2. **Add to Quick Navigation:**
   ```bash
   echo "- [🎨 New Section](#-new-section)" >> "$output_file"
   ```
3. **Add section generation:**
   ```bash
   echo "## 🎨 New Section" >> "$output_file"
   # Add file discovery logic
   ```

### Custom File Ordering

Modify the `ordered_files` array in the script:

```bash
local ordered_files=(
    "rdash-document.md"
    "types-and-enums.md"     # Prioritized for early discovery
    "your-new-file.md"       # Add custom ordering
    "data-sources.md"
    # ... rest of files
)
```

### Workspace Customization

Edit `Reveal.Sdk.Dom.code-workspace` to:
- **Add custom tasks** for your workflow
- **Modify preview settings** (fonts, colors, etc.)
- **Add project-specific extensions**
- **Configure custom keybindings**

## 🎯 Best Practices

### Documentation Workflow

1. **Start with TOC** - Always check the generated TOC for overview
2. **Use workspace** - Open `Reveal.Sdk.Dom.code-workspace` for best experience
3. **Preview as you write** - Use side-by-side preview mode
4. **Update TOC regularly** - Run the generator after adding new files
5. **Check links** - Use VS Code's built-in link validation

### Writing Tips

- **Front-load important info** - Types & Enums are prioritized for early discovery
- **Use consistent headings** - The TOC generator reads first `#` heading
- **Cross-reference liberally** - Link between related documents
- **Include examples** - Code samples make concepts concrete
- **Update regularly** - Keep documentation current with code changes

## 🚨 Troubleshooting

### Common Issues

**TOC not generating:**
```bash
# Check permissions
chmod +x scripts/generate-toc.sh

# Check Python (for relative path calculation)
python3 --version
```

**VS Code preview not working:**
- Install recommended extensions
- Check that file associations are correct
- Restart VS Code after workspace setup

**Links not working:**
- Use relative paths (e.g., `../core-concepts/types.md`)
- Check file paths match actual structure
- Regenerate TOC to fix broken references

### Getting Help

- **VS Code issues:** Check the Extensions tab for recommended extensions
- **Script issues:** Run with bash debugging: `bash -x generate-toc.sh`
- **Path issues:** Use absolute paths in script options for testing

---

*This documentation management system is designed to scale with your project and make documentation maintenance effortless.*