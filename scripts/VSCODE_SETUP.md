# VS Code 2-Pane Documentation Setup

## Quick Setup Instructions

### Method 1: Manual Split-Pane in VS Code

1. **Open VS Code workspace:**
   ```bash
   # If VS Code CLI is available:
   code Reveal.Sdk.Dom.code-workspace
   
   # Or manually: File → Open Workspace → Reveal.Sdk.Dom.code-workspace
   ```

2. **Set up 2-pane view:**
   - Open `docs/TABLE_OF_CONTENTS.md`
   - Press `Cmd+\` (Mac) or `Ctrl+\` (Windows/Linux) to split editor
   - Left pane: Keep `TABLE_OF_CONTENTS.md` open
   - Right pane: Will show content as you navigate

3. **Navigate:**
   - **Cmd+Click** (Mac) or **Ctrl+Click** (Windows/Linux) on TOC links
   - Links will open in the right pane automatically
   - Keep TOC open on the left for constant navigation

### Method 2: Use VS Code's Markdown Preview

1. **Open workspace and TOC:**
   ```bash
   code Reveal.Sdk.Dom.code-workspace
   ```

2. **Set up preview panes:**
   - Open `docs/TABLE_OF_CONTENTS.md`
   - Press `Cmd+K V` (Mac) or `Ctrl+K V` (Windows/Linux) for side-by-side preview
   - Split the editor: `Cmd+\` (Mac) or `Ctrl+\` (Windows/Linux)
   - Now you have: TOC source | TOC preview | Content

3. **Navigation:**
   - Click links in the TOC preview (middle pane)
   - Content opens in the right pane
   - Left pane keeps the TOC source for quick reference

## VS Code Extensions for Better Experience

Install these extensions for optimal documentation viewing:

### Essential Extensions
- **Markdown All in One** (`yzhang.markdown-all-in-one`)
- **Markdown Preview Enhanced** (`shd101wyy.markdown-preview-enhanced`)
- **markdownlint** (`davidanson.vscode-markdownlint`)

### Installation Commands
```bash
# Install via command line (if code CLI is available)
code --install-extension yzhang.markdown-all-in-one
code --install-extension shd101wyy.markdown-preview-enhanced
code --install-extension davidanson.vscode-markdownlint
```

Or install via VS Code:
1. Open Extensions (`Cmd+Shift+X` / `Ctrl+Shift+X`)
2. Search for each extension name
3. Click "Install"

## VS Code Settings for 2-Pane Documentation

Add these to your VS Code settings for better documentation experience:

### User Settings (Cmd+, / Ctrl+,)
```json
{
    "markdown.preview.openMarkdownLinks": "inEditor",
    "markdown.preview.scrollEditorWithPreview": true,
    "markdown.preview.scrollPreviewWithEditor": true,
    "workbench.editor.enablePreview": false,
    "workbench.editor.enablePreviewFromQuickOpen": false,
    "explorer.openEditors.visible": 0,
    "markdown.preview.fontSize": 14,
    "markdown.preview.lineHeight": 1.6
}
```

## Keyboard Shortcuts for Documentation Navigation

| Action | Mac | Windows/Linux | Description |
|--------|-----|---------------|-------------|
| Split editor | `Cmd+\` | `Ctrl+\` | Create side-by-side panes |
| Preview mode | `Cmd+Shift+V` | `Ctrl+Shift+V` | Full preview mode |
| Side preview | `Cmd+K V` | `Ctrl+K V` | Side-by-side preview |
| Quick open | `Cmd+P` | `Ctrl+P` | Quick file switcher |
| Search files | `Cmd+Shift+F` | `Ctrl+Shift+F` | Global search |
| Follow link | `Cmd+Click` | `Ctrl+Click` | Open link in editor |
| Go back | `Cmd+Alt+←` | `Ctrl+Alt+←` | Navigate backward |
| Go forward | `Cmd+Alt+→` | `Ctrl+Alt+→` | Navigate forward |

## Workspace Tasks

The workspace includes these tasks (accessible via `Cmd+Shift+P` → "Tasks"):

- **Generate Documentation TOC** - Regenerate table of contents
- **Open Documentation TOC** - Quick access to TOC
- **Preview Documentation** - Show preview shortcuts

## Tips for Optimal 2-Pane Experience

### Layout Recommendations

1. **3-Column Layout:**
   ```
   [TOC Source] | [TOC Preview] | [Content]
   ```

2. **2-Column Layout:**
   ```
   [TOC Preview] | [Content]
   ```

3. **Tabbed Layout:**
   ```
   Keep TOC pinned, content in tabs
   ```

### Navigation Workflow

1. **Keep TOC always visible** - Pin the TOC tab
2. **Use Cmd/Ctrl+Click** - Opens in adjacent pane
3. **Use breadcrumbs** - Shows location context
4. **Use outline panel** - Quick section navigation
5. **Use search** - Find content across all docs

### Customization Options

Edit `Reveal.Sdk.Dom.code-workspace` to customize:

```json
{
  "settings": {
    "workbench.colorTheme": "GitHub Light",
    "markdown.preview.fontFamily": "Georgia, serif",
    "markdown.preview.fontSize": 16,
    "editor.wordWrap": "on",
    "editor.lineNumbers": "off"
  }
}
```

## VS Code Command Palette Commands

Access via `Cmd+Shift+P` (Mac) or `Ctrl+Shift+P` (Windows/Linux):

- **"Markdown: Open Preview"** - Open preview pane
- **"Markdown: Open Preview to the Side"** - Side-by-side preview
- **"View: Split Editor"** - Create additional pane
- **"View: Toggle Editor Group Layout"** - Switch between layouts
- **"File: Pin Tab"** - Keep important files open

## Troubleshooting VS Code Setup

### Links Not Working
- Ensure relative paths are correct
- Check that linked files exist
- Use `Cmd/Ctrl+Click` instead of regular click

### Preview Not Updating
- Install "Markdown All in One" extension
- Reload VS Code window
- Check file is saved (auto-save should be enabled)

### Performance Issues
- Close unused preview tabs
- Disable unnecessary extensions
- Use "workbench.editor.limit.enabled": true in settings

---

*This setup gives you a professional documentation browsing experience directly in VS Code!*