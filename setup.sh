#!/bin/bash

echo "======================================"
echo "Community Garden Management System"
echo "Setup Script"
echo "======================================"
echo ""

# Check if .NET is installed
if ! command -v dotnet &> /dev/null; then
    echo "Error: .NET SDK is not installed."
    echo "Please install .NET 10.0 SDK or higher from:"
    echo "https://dotnet.microsoft.com/download"
    exit 1
fi

echo "✓ .NET SDK detected: $(dotnet --version)"
echo ""

# Navigate to project directory
cd WebApplication1

echo "Step 1: Restoring NuGet packages..."
dotnet restore

if [ $? -ne 0 ]; then
    echo "Error: Failed to restore packages"
    exit 1
fi

echo "✓ Packages restored successfully"
echo ""

echo "Step 2: Building the project..."
dotnet build

if [ $? -ne 0 ]; then
    echo "Error: Build failed"
    exit 1
fi

echo "✓ Build completed successfully"
echo ""

echo "Step 3: Applying database migrations..."
dotnet ef database update

if [ $? -ne 0 ]; then
    echo "Warning: Database migration failed. You may need to install dotnet-ef:"
    echo "  dotnet tool install --global dotnet-ef"
else
    echo "✓ Database updated successfully"
fi

echo ""
echo "======================================"
echo "Setup completed successfully!"
echo "======================================"
echo ""
echo "To run the application:"
echo "  cd WebApplication1"
echo "  dotnet run"
echo ""
echo "Then open your browser to:"
echo "  http://localhost:5000"
echo ""
