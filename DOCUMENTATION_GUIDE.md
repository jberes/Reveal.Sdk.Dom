# Quick Reference: Viewing Documentation in VS Code

## 🚀 Getting Started

### 1. Open the Workspace
- Open VS Code
- Go to `File` → `Open Workspace from File...`
- Select `Reveal.Sdk.Dom.code-workspace`
- Click "Install" when prompted for recommended extensions

### 2. Navigate to Documentation
- Use the Explorer panel (Cmd+Shift+E / Ctrl+Shift+E)
- Open the `docs` folder
- Start with `TABLE_OF_CONTENTS.md` for overview

## 📖 Preview Modes

### Side-by-Side Preview (Recommended)
1. Open any `.md` file (e.g., `docs/TABLE_OF_CONTENTS.md`)
2. Press `Cmd+K V` (Mac) or `Ctrl+K V` (Windows/Linux)
3. Edit on the left, preview on the right
4. Changes appear instantly in preview

### Full Preview Mode
1. Open any `.md` file
2. Press `Cmd+Shift+V` (Mac) or `Ctrl+Shift+V` (Windows/Linux)
3. View full-screen formatted preview
4. Click links to navigate between documents

### Quick Link Navigation
- **Cmd+Click** (Mac) or **Ctrl+Click** (Windows/Linux) on any link
- Links between docs work automatically
- Use "Back" button or `Cmd+Alt+←` to return

## 🔧 Essential Keyboard Shortcuts

| Action | Mac | Windows/Linux |
|--------|-----|---------------|
| Side-by-side preview | `Cmd+K V` | `Ctrl+K V` |
| Full preview | `Cmd+Shift+V` | `Ctrl+Shift+V` |
| Quick file open | `Cmd+P` | `Ctrl+P` |
| Search across files | `Cmd+Shift+F` | `Ctrl+Shift+F` |
| Navigate back | `Cmd+Alt+←` | `Ctrl+Alt+←` |
| Navigate forward | `Cmd+Alt+→` | `Ctrl+Alt+→` |
| Open explorer | `Cmd+Shift+E` | `Ctrl+Shift+E` |
| Command palette | `Cmd+Shift+P` | `Ctrl+Shift+P` |

## 📋 Using the Table of Contents

### Quick Start
1. Open `docs/TABLE_OF_CONTENTS.md`
2. Use side-by-side preview (`Cmd+K V` / `Ctrl+K V`)
3. Click any link in the TOC to navigate
4. Use the quick navigation section at the top

### Regenerating TOC
1. Open terminal in VS Code (`Cmd+`` / `Ctrl+``)
2. Run: `cd scripts && ./generate-toc.sh`
3. Or use Command Palette → "Tasks: Run Task" → "Generate Documentation TOC"

## 🎯 Documentation Reading Path

### For New Users
1. **[Table of Contents](docs/TABLE_OF_CONTENTS.md)** - Start here for overview
2. **[Basic Concepts](docs/getting-started/basic-concepts.md)** - Essential understanding
3. **[Types and Enums](docs/core-concepts/types-and-enums.md)** - Critical reference
4. **[Quick Start](docs/getting-started/quick-start.md)** - First working example

### For Specific Tasks
1. **Data Sources**: Check `docs/how-to/data-sources/` folder
2. **Visualizations**: Check `docs/how-to/visualizations/` folder
3. **Enterprise Patterns**: Check enterprise guides in `docs/how-to/`
4. **API Reference**: Check `docs/api-reference/` folder

### For Troubleshooting
1. **[FAQ](docs/faq.md)** - Common questions
2. **[Troubleshooting](docs/troubleshooting.md)** - Common issues
3. **[Glossary](docs/glossary.md)** - Term definitions

## 🔍 Search and Navigation Tips

### Finding Information
- **Global search**: `Cmd+Shift+F` / `Ctrl+Shift+F` and search across all docs
- **Quick file open**: `Cmd+P` / `Ctrl+P` and type filename
- **In-file search**: `Cmd+F` / `Ctrl+F` when viewing a document

### Using the Outline
1. Open any markdown file
2. Look for the "Outline" panel (usually on the right)
3. Click headings to jump to sections
4. Use this for quick navigation within long documents

### Following Cross-References
- Links between documents work automatically
- Hover over links to see file path
- Ctrl/Cmd+Click to open in new tab
- Use breadcrumbs to understand location context

## 🎨 Customizing the Experience

### Better Reading Experience
The workspace configures:
- ✅ **Optimized fonts** for reading
- ✅ **Proper line spacing** 
- ✅ **Hidden UI elements** that distract from content
- ✅ **Auto-save** so you don't lose changes
- ✅ **Spell checking** with SDK-specific terms

### Recommended Extensions
Install these for the best experience:
- **Markdown All in One** - Enhanced editing
- **Markdown Preview Enhanced** - Advanced previews
- **Code Spell Checker** - Spell checking
- **markdownlint** - Style checking

## 📊 Documentation Overview

Based on the current stats from the generated TOC:

- **📁 Total Files**: 25 documentation files
- **📄 Total Lines**: 12,330+ lines of documentation
- **📝 Estimated Words**: 33,989+ words
- **🎯 Coverage**: Complete SDK coverage with enterprise examples

### Content Structure
- **🚀 Getting Started**: 3 files - Installation, concepts, quick start
- **📚 Core Concepts**: Types, data sources, visualizations
- **📖 How-To Guides**: 8 files including 4 enterprise patterns
- **📋 API Reference**: Complete type and method references
- **💡 Examples**: Working dashboard examples
- **📄 Resources**: FAQ, troubleshooting, glossary

## 🚨 Troubleshooting

### Preview Not Working
1. Install recommended extensions
2. Restart VS Code
3. Check file is saved (auto-save enabled in workspace)

### Links Not Working
1. Use relative paths (e.g., `../core-concepts/types.md`)
2. Check file actually exists in expected location
3. Regenerate TOC to verify structure

### Performance Issues
1. Close unused preview tabs
2. Use quick file open (`Cmd+P` / `Ctrl+P`) instead of scrolling
3. Search in specific folders using `files:docs/how-to/` in search

---

**💡 Pro Tip**: Keep the Table of Contents open in one tab and use it as your navigation hub. The quick navigation links at the top make it easy to jump between sections!