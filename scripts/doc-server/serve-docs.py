#!/usr/bin/env python3
"""
Reveal.Sdk.Dom Documentation Server

A lightweight web server that provides a 2-pane documentation browser
with TOC on the left and content on the right.

Usage:
    python3 serve-docs.py [--port PORT] [--host HOST] [--docs-path PATH]
    
Default:
    python3 serve-docs.py
    
Then open: http://localhost:8080
"""

import os
import sys
import argparse
import json
import urllib.parse
from pathlib import Path
from http.server import HTTPServer, BaseHTTPRequestHandler
import mimetypes
import webbrowser
import threading
import time

class DocumentationHandler(BaseHTTPRequestHandler):
    def __init__(self, *args, docs_root=None, **kwargs):
        self.docs_root = docs_root or Path("../../docs").resolve()
        self.server_root = Path(__file__).parent
        super().__init__(*args, **kwargs)
        
    def log_message(self, format, *args):
        """Override to provide cleaner logging"""
        print(f"📡 {self.address_string()} - {format % args}")
    
    def do_GET(self):
        """Handle GET requests"""
        try:
            parsed_path = urllib.parse.urlparse(self.path)
            path = parsed_path.path
            query = urllib.parse.parse_qs(parsed_path.query)
            
            # Route requests
            if path == '/':
                self.serve_index()
            elif path == '/simple':
                self.serve_simple()
            elif path == '/debug':
                self.serve_debug()
            elif path == '/api/toc':
                self.serve_toc()
            elif path == '/api/doc':
                doc_path = query.get('path', [''])[0]
                self.serve_document(doc_path)
            elif path.startswith('/api/'):
                self.serve_error(404, "API endpoint not found")
            else:
                # Serve static files (CSS, JS, images)
                self.serve_static_file(path)
                
        except Exception as e:
            print(f"❌ Error handling request: {e}")
            self.serve_error(500, f"Internal server error: {str(e)}")
    
    def serve_index(self):
        """Serve the main documentation interface"""
        try:
            index_path = self.server_root / "index-fixed.html"
            with open(index_path, 'r', encoding='utf-8') as f:
                content = f.read()
            
            self.send_response(200)
            self.send_header('Content-Type', 'text/html; charset=utf-8')
            self.send_header('Cache-Control', 'no-cache')
            self.end_headers()
            self.wfile.write(content.encode('utf-8'))
            
        except FileNotFoundError:
            self.serve_error(500, "Documentation interface not found")
    
    def serve_debug(self):
        """Serve the debug page"""
        try:
            debug_path = self.server_root / "debug.html"
            with open(debug_path, 'r', encoding='utf-8') as f:
                content = f.read()
            
            self.send_response(200)
            self.send_header('Content-Type', 'text/html; charset=utf-8')
            self.send_header('Cache-Control', 'no-cache')
            self.end_headers()
            self.wfile.write(content.encode('utf-8'))
            
        except FileNotFoundError:
            self.serve_error(500, "Debug page not found")
    
    def serve_simple(self):
        """Serve the simple documentation interface"""
        try:
            simple_path = self.server_root / "index-simple.html"
            with open(simple_path, 'r', encoding='utf-8') as f:
                content = f.read()
            
            self.send_response(200)
            self.send_header('Content-Type', 'text/html; charset=utf-8')
            self.send_header('Cache-Control', 'no-cache')
            self.end_headers()
            self.wfile.write(content.encode('utf-8'))
            
        except FileNotFoundError:
            self.serve_error(500, "Simple documentation interface not found")
    
    def serve_toc(self):
        """Serve the table of contents"""
        try:
            toc_path = self.docs_root / "TABLE_OF_CONTENTS.md"
            
            if not toc_path.exists():
                # Generate TOC if it doesn't exist
                self.generate_toc()
            
            with open(toc_path, 'r', encoding='utf-8') as f:
                content = f.read()
            
            self.send_response(200)
            self.send_header('Content-Type', 'text/plain; charset=utf-8')
            self.send_header('Cache-Control', 'no-cache')
            self.send_header('Access-Control-Allow-Origin', '*')  # Add CORS support
            self.end_headers()
            self.wfile.write(content.encode('utf-8'))
            
        except Exception as e:
            print(f"❌ Error serving TOC: {e}")
            self.serve_error(500, f"Error loading table of contents: {str(e)}")
    
    def serve_document(self, doc_path):
        """Serve a specific markdown document"""
        try:
            print(f"📄 Serving document: {doc_path}")  # Debug log
            
            if not doc_path:
                print("❌ No document path provided")
                self.serve_error(400, "Document path required")
                return
            
            # Security: ensure path is within docs directory
            full_path = (self.docs_root / doc_path).resolve()
            print(f"📁 Full path: {full_path}")  # Debug log
            print(f"📁 Docs root: {self.docs_root}")  # Debug log
            
            # Check if path is within docs root (security measure)
            if not str(full_path).startswith(str(self.docs_root)):
                print(f"❌ Access denied: path outside docs directory")
                self.serve_error(403, "Access denied: path outside docs directory")
                return
            
            if not full_path.exists():
                print(f"❌ File not found: {full_path}")
                self.serve_error(404, f"Document not found: {doc_path}")
                return
            
            if not full_path.suffix.lower() == '.md':
                print(f"❌ Not a markdown file: {full_path}")
                self.serve_error(400, "Only markdown files are supported")
                return
            
            with open(full_path, 'r', encoding='utf-8') as f:
                content = f.read()
            
            print(f"✅ Successfully loaded document: {len(content)} characters")
            
            self.send_response(200)
            self.send_header('Content-Type', 'text/plain; charset=utf-8')
            self.send_header('Cache-Control', 'no-cache')
            self.send_header('Access-Control-Allow-Origin', '*')  # Add CORS support
            self.end_headers()
            self.wfile.write(content.encode('utf-8'))
            
        except Exception as e:
            print(f"❌ Error serving document '{doc_path}': {e}")
            self.serve_error(500, f"Error loading document: {str(e)}")
    
    def serve_static_file(self, path):
        """Serve static files like CSS, JS, images"""
        try:
            # Remove leading slash
            if path.startswith('/'):
                path = path[1:]
            
            file_path = self.server_root / path
            
            if not file_path.exists():
                self.serve_error(404, f"File not found: {path}")
                return
            
            # Get MIME type
            mime_type, _ = mimetypes.guess_type(str(file_path))
            if mime_type is None:
                mime_type = 'application/octet-stream'
            
            with open(file_path, 'rb') as f:
                content = f.read()
            
            self.send_response(200)
            self.send_header('Content-Type', mime_type)
            self.send_header('Cache-Control', 'public, max-age=3600')  # 1 hour cache
            self.end_headers()
            self.wfile.write(content)
            
        except Exception as e:
            print(f"❌ Error serving static file '{path}': {e}")
            self.serve_error(500, f"Error loading file: {str(e)}")
    
    def serve_error(self, code, message):
        """Serve an error response"""
        self.send_response(code)
        self.send_header('Content-Type', 'text/plain; charset=utf-8')
        self.end_headers()
        self.wfile.write(message.encode('utf-8'))
    
    def generate_toc(self):
        """Generate TOC if it doesn't exist"""
        try:
            print("📋 Generating table of contents...")
            toc_script = self.docs_root.parent / "scripts" / "generate-toc.sh"
            
            if toc_script.exists():
                os.system(f"cd '{toc_script.parent}' && ./generate-toc.sh")
                print("✅ TOC generated successfully")
            else:
                print("⚠️  TOC generation script not found")
                
        except Exception as e:
            print(f"❌ Error generating TOC: {e}")

def create_handler_class(docs_root):
    """Factory function to create handler class with docs_root"""
    class Handler(DocumentationHandler):
        def __init__(self, *args, **kwargs):
            super().__init__(*args, docs_root=docs_root, **kwargs)
    return Handler

def open_browser(url, delay=1.5):
    """Open browser after a short delay"""
    time.sleep(delay)
    webbrowser.open(url)
    print(f"🌐 Opened browser: {url}")

def main():
    parser = argparse.ArgumentParser(
        description="Serve Reveal.Sdk.Dom documentation with 2-pane interface"
    )
    parser.add_argument(
        '--port', '-p', 
        type=int, 
        default=8080,
        help='Port to serve on (default: 8080)'
    )
    parser.add_argument(
        '--host', 
        default='localhost',
        help='Host to serve on (default: localhost)'
    )
    parser.add_argument(
        '--docs-path', 
        type=Path,
        default=Path(__file__).parent.parent.parent / "docs",
        help='Path to docs directory (default: ../../docs)'
    )
    parser.add_argument(
        '--no-browser',
        action='store_true',
        help='Do not open browser automatically'
    )
    
    args = parser.parse_args()
    
    # Resolve docs path
    docs_root = args.docs_path.resolve()
    
    if not docs_root.exists():
        print(f"❌ Documentation directory not found: {docs_root}")
        print("💡 Make sure you're running from the correct directory")
        sys.exit(1)
    
    print(f"📚 Reveal.Sdk.Dom Documentation Server")
    print(f"📁 Docs directory: {docs_root}")
    print(f"🌐 Starting server at http://{args.host}:{args.port}")
    
    # Create handler class with docs root
    handler_class = create_handler_class(docs_root)
    
    try:
        # Create server
        server = HTTPServer((args.host, args.port), handler_class)
        
        # Open browser in background thread
        if not args.no_browser:
            url = f"http://{args.host}:{args.port}"
            browser_thread = threading.Thread(target=open_browser, args=(url,))
            browser_thread.daemon = True
            browser_thread.start()
        
        print(f"✅ Server running! Visit http://{args.host}:{args.port}")
        print("📖 Features:")
        print("   • TOC navigation on the left")
        print("   • Document content on the right") 
        print("   • Search functionality")
        print("   • Keyboard shortcuts (Ctrl/Cmd + ← → for navigation)")
        print("   • Auto-refresh TOC")
        print()
        print("⌨️  Keyboard shortcuts:")
        print("   • Ctrl/Cmd + ← : Previous document")
        print("   • Ctrl/Cmd + → : Next document") 
        print("   • Ctrl/Cmd + F : Focus search")
        print()
        print("🛑 Press Ctrl+C to stop the server")
        print()
        
        # Start serving
        server.serve_forever()
        
    except KeyboardInterrupt:
        print("\n🛑 Shutting down server...")
        server.shutdown()
        print("✅ Server stopped")
        
    except OSError as e:
        if e.errno == 48:  # Address already in use
            print(f"❌ Port {args.port} is already in use")
            print(f"💡 Try a different port: python3 serve-docs.py --port {args.port + 1}")
        else:
            print(f"❌ Server error: {e}")
        sys.exit(1)
        
    except Exception as e:
        print(f"❌ Unexpected error: {e}")
        sys.exit(1)

if __name__ == '__main__':
    main()