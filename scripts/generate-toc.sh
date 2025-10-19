#!/bin/bash

# Generate Table of Contents for Reveal.Sdk.Dom Documentation
# This script scans the docs folder and generates a comprehensive TOC

DOCS_PATH="../docs"
OUTPUT_FILE="../docs/TABLE_OF_CONTENTS.md"
OPEN_IN_VSCODE=false

# Parse command line arguments
while [[ $# -gt 0 ]]; do
    case $1 in
        --docs-path)
            DOCS_PATH="$2"
            shift 2
            ;;
        --output)
            OUTPUT_FILE="$2"
            shift 2
            ;;
        --open)
            OPEN_IN_VSCODE=true
            shift
            ;;
        *)
            echo "Unknown option $1"
            exit 1
            ;;
    esac
done

# Function to get markdown title from file
get_markdown_title() {
    local file="$1"
    if [[ -f "$file" ]]; then
        # Get first line that starts with #
        local title=$(head -10 "$file" | grep -m1 '^#[[:space:]]' | sed 's/^#[[:space:]]*//')
        if [[ -n "$title" ]]; then
            echo "$title"
        else
            # Fallback to filename without extension
            basename "$file" .md
        fi
    else
        basename "$file" .md
    fi
}

# Function to get relative path
get_relative_path() {
    local from_dir=$(dirname "$1")
    local to_file="$2"
    python3 -c "import os.path; print(os.path.relpath('$to_file', '$from_dir'))"
}

# Main function to generate TOC
generate_toc() {
    local base_path="$1"
    local output_file="$2"
    
    echo "# Reveal.Sdk.Dom Documentation - Table of Contents" > "$output_file"
    echo "" >> "$output_file"
    echo "*Generated on: $(date '+%Y-%m-%d %H:%M:%S')*" >> "$output_file"
    echo "" >> "$output_file"
    echo "## Quick Navigation" >> "$output_file"
    echo "" >> "$output_file"
    
    # Quick navigation links
    echo "- [🚀 Getting Started](#-getting-started)" >> "$output_file"
    echo "- [📚 Core Concepts](#-core-concepts)" >> "$output_file"
    echo "- [📖 How-To Guides](#-how-to-guides)" >> "$output_file"
    echo "- [📋 API Reference](#-api-reference)" >> "$output_file"
    echo "- [💡 Examples](#-examples)" >> "$output_file"
    echo "- [📄 Additional Resources](#-additional-resources)" >> "$output_file"
    echo "" >> "$output_file"
    echo "---" >> "$output_file"
    echo "" >> "$output_file"
    
    # Getting Started
    echo "## 🚀 Getting Started" >> "$output_file"
    echo "" >> "$output_file"
    if [[ -d "$base_path/getting-started" ]]; then
        for file in "$base_path/getting-started"/*.md; do
            if [[ -f "$file" ]]; then
                local title=$(get_markdown_title "$file")
                local rel_path=$(get_relative_path "$output_file" "$file")
                echo "- [$title]($rel_path)" >> "$output_file"
            fi
        done
    fi
    echo "" >> "$output_file"
    
    # Core Concepts
    echo "## 📚 Core Concepts" >> "$output_file"
    echo "" >> "$output_file"
    if [[ -d "$base_path/core-concepts" ]]; then
        # Specific order for core concepts
        local ordered_files=(
            "rdash-document.md"
            "types-and-enums.md"
            "data-sources.md"
            "visualizations.md"
            "filters.md"
            "variables.md"
            "document-structure.md"
        )
        
        for filename in "${ordered_files[@]}"; do
            local filepath="$base_path/core-concepts/$filename"
            if [[ -f "$filepath" ]]; then
                local title=$(get_markdown_title "$filepath")
                local rel_path=$(get_relative_path "$output_file" "$filepath")
                echo "- [$title]($rel_path)" >> "$output_file"
            fi
        done
        
        # Add any additional files not in ordered list
        for file in "$base_path/core-concepts"/*.md; do
            if [[ -f "$file" ]]; then
                local filename=$(basename "$file")
                local found=false
                for ordered_file in "${ordered_files[@]}"; do
                    if [[ "$filename" == "$ordered_file" ]]; then
                        found=true
                        break
                    fi
                done
                if [[ "$found" == false ]]; then
                    local title=$(get_markdown_title "$file")
                    local rel_path=$(get_relative_path "$output_file" "$file")
                    echo "- [$title]($rel_path)" >> "$output_file"
                fi
            fi
        done
    fi
    echo "" >> "$output_file"
    
    # How-To Guides
    echo "## 📖 How-To Guides" >> "$output_file"
    echo "" >> "$output_file"
    
    # Data Sources
    if [[ -d "$base_path/how-to/data-sources" ]]; then
        echo "### 🔌 Data Sources" >> "$output_file"
        for file in "$base_path/how-to/data-sources"/*.md; do
            if [[ -f "$file" ]]; then
                local title=$(get_markdown_title "$file")
                local rel_path=$(get_relative_path "$output_file" "$file")
                echo "- [$title]($rel_path)" >> "$output_file"
            fi
        done
        echo "" >> "$output_file"
    fi
    
    # Visualizations
    if [[ -d "$base_path/how-to/visualizations" ]]; then
        echo "### 📊 Visualizations" >> "$output_file"
        for file in "$base_path/how-to/visualizations"/*.md; do
            if [[ -f "$file" ]]; then
                local title=$(get_markdown_title "$file")
                local rel_path=$(get_relative_path "$output_file" "$file")
                echo "- [$title]($rel_path)" >> "$output_file"
            fi
        done
        echo "" >> "$output_file"
    fi
    
    # Root level how-to files (enterprise & advanced)
    local has_root_files=false
    for file in "$base_path/how-to"/*.md; do
        if [[ -f "$file" ]]; then
            if [[ "$has_root_files" == false ]]; then
                echo "### 🏢 Enterprise & Advanced" >> "$output_file"
                has_root_files=true
            fi
            local title=$(get_markdown_title "$file")
            local rel_path=$(get_relative_path "$output_file" "$file")
            echo "- [$title]($rel_path)" >> "$output_file"
        fi
    done
    if [[ "$has_root_files" == true ]]; then
        echo "" >> "$output_file"
    fi
    
    # API Reference
    echo "## 📋 API Reference" >> "$output_file"
    echo "" >> "$output_file"
    
    if [[ -f "$base_path/api-reference/data-sources/README.md" ]]; then
        echo "### Data Sources" >> "$output_file"
        local title=$(get_markdown_title "$base_path/api-reference/data-sources/README.md")
        local rel_path=$(get_relative_path "$output_file" "$base_path/api-reference/data-sources/README.md")
        echo "- [$title]($rel_path)" >> "$output_file"
        echo "" >> "$output_file"
    fi
    
    if [[ -f "$base_path/api-reference/visualizations/README.md" ]]; then
        echo "### Visualizations" >> "$output_file"
        local title=$(get_markdown_title "$base_path/api-reference/visualizations/README.md")
        local rel_path=$(get_relative_path "$output_file" "$base_path/api-reference/visualizations/README.md")
        echo "- [$title]($rel_path)" >> "$output_file"
        echo "" >> "$output_file"
    fi
    
    # Examples
    echo "## 💡 Examples" >> "$output_file"
    echo "" >> "$output_file"
    if [[ -d "$base_path/examples" ]]; then
        for file in "$base_path/examples"/*.md; do
            if [[ -f "$file" ]]; then
                local title=$(get_markdown_title "$file")
                local rel_path=$(get_relative_path "$output_file" "$file")
                echo "- [$title]($rel_path)" >> "$output_file"
            fi
        done
    fi
    echo "" >> "$output_file"
    
    # Additional Resources
    echo "## 📄 Additional Resources" >> "$output_file"
    echo "" >> "$output_file"
    
    local additional_files=(
        "best-practices.md"
        "troubleshooting.md"
        "faq.md"
        "glossary.md"
    )
    
    for filename in "${additional_files[@]}"; do
        local filepath="$base_path/$filename"
        if [[ -f "$filepath" ]]; then
            local title=$(get_markdown_title "$filepath")
            local rel_path=$(get_relative_path "$output_file" "$filepath")
            echo "- [$title]($rel_path)" >> "$output_file"
        fi
    done
    
    echo "" >> "$output_file"
    echo "---" >> "$output_file"
    echo "" >> "$output_file"
    echo "## 📈 Documentation Statistics" >> "$output_file"
    echo "" >> "$output_file"
    
    # Calculate statistics
    local total_files=$(find "$base_path" -name "*.md" | wc -l)
    local total_lines=$(find "$base_path" -name "*.md" -exec wc -l {} + | tail -1 | awk '{print $1}')
    local total_words=$(find "$base_path" -name "*.md" -exec wc -w {} + | tail -1 | awk '{print $1}')
    
    echo "- **Total Documentation Files**: $total_files" >> "$output_file"
    echo "- **Total Lines**: $(printf "%'d" $total_lines)" >> "$output_file"
    echo "- **Estimated Total Words**: $(printf "%'d" $total_words)" >> "$output_file"
    echo "- **Last Updated**: $(date '+%Y-%m-%d')" >> "$output_file"
    echo "" >> "$output_file"
    echo "*This TOC was automatically generated. To regenerate, run: \`scripts/generate-toc.sh\`*" >> "$output_file"
}

# Main execution
FULL_DOCS_PATH=$(realpath "$DOCS_PATH")
OUTPUT_DIR=$(dirname "$OUTPUT_FILE")
OUTPUT_FILENAME=$(basename "$OUTPUT_FILE")
FULL_OUTPUT_FILE="$OUTPUT_DIR/$OUTPUT_FILENAME"

echo "🔍 Generating Table of Contents..."
echo "📁 Docs Path: $FULL_DOCS_PATH"
echo "📄 Output File: $FULL_OUTPUT_FILE"

generate_toc "$FULL_DOCS_PATH" "$FULL_OUTPUT_FILE"

echo "✅ Table of Contents generated successfully!"
echo "📁 File saved to: $FULL_OUTPUT_FILE"

if [[ "$OPEN_IN_VSCODE" == true ]]; then
    echo "🚀 Opening in VS Code..."
    code "$FULL_OUTPUT_FILE"
fi