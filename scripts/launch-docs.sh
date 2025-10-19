#!/bin/bash
# Quick launcher for the documentation server

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
BLUE='\033[0;34m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

echo -e "${BLUE}🚀 Launching Reveal.Sdk.Dom Documentation Server${NC}"
echo

# Check if Python 3 is available
if ! command -v python3 &> /dev/null; then
    echo -e "${RED}❌ Python 3 is required but not found${NC}"
    echo -e "${YELLOW}💡 Please install Python 3 and try again${NC}"
    exit 1
fi

# Get the script directory
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
SERVER_SCRIPT="$SCRIPT_DIR/doc-server/serve-docs.py"

if [ ! -f "$SERVER_SCRIPT" ]; then
    echo -e "${RED}❌ Documentation server script not found: $SERVER_SCRIPT${NC}"
    exit 1
fi

# Check if docs directory exists
DOCS_DIR="$(cd "$SCRIPT_DIR/../../docs" && pwd)"
if [ ! -d "$DOCS_DIR" ]; then
    echo -e "${RED}❌ Documentation directory not found: $DOCS_DIR${NC}"
    exit 1
fi

echo -e "${GREEN}📁 Documentation directory: $DOCS_DIR${NC}"
echo -e "${GREEN}🐍 Using Python: $(python3 --version)${NC}"
echo

# Parse command line arguments
PORT=8080
HOST="localhost"
NO_BROWSER=""

while [[ $# -gt 0 ]]; do
    case $1 in
        -p|--port)
            PORT="$2"
            shift 2
            ;;
        --host)
            HOST="$2"
            shift 2
            ;;
        --no-browser)
            NO_BROWSER="--no-browser"
            shift
            ;;
        -h|--help)
            echo "Usage: $0 [OPTIONS]"
            echo
            echo "Options:"
            echo "  -p, --port PORT     Port to serve on (default: 8080)"
            echo "  --host HOST         Host to serve on (default: localhost)"
            echo "  --no-browser        Don't open browser automatically"
            echo "  -h, --help          Show this help message"
            echo
            echo "Examples:"
            echo "  $0                  # Start on localhost:8080"
            echo "  $0 -p 3000          # Start on port 3000"
            echo "  $0 --no-browser     # Start without opening browser"
            exit 0
            ;;
        *)
            echo -e "${RED}❌ Unknown option: $1${NC}"
            echo "Use --help for usage information"
            exit 1
            ;;
    esac
done

# Generate TOC if it doesn't exist
TOC_FILE="$DOCS_DIR/TABLE_OF_CONTENTS.md"
if [ ! -f "$TOC_FILE" ]; then
    echo -e "${YELLOW}📋 Table of Contents not found. Generating...${NC}"
    cd "$SCRIPT_DIR" && ./generate-toc.sh
    if [ $? -eq 0 ]; then
        echo -e "${GREEN}✅ TOC generated successfully${NC}"
    else
        echo -e "${YELLOW}⚠️  Warning: Could not generate TOC automatically${NC}"
    fi
    echo
fi

echo -e "${BLUE}🌐 Starting server on http://$HOST:$PORT${NC}"
echo -e "${BLUE}📖 Your 2-pane documentation browser will open shortly...${NC}"
echo

# Start the server
python3 "$SERVER_SCRIPT" --port "$PORT" --host "$HOST" $NO_BROWSER