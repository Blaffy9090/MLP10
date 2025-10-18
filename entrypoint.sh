#!/bin/bash
# Wait a bit for SQL Server to be ready (optional but safe)
echo "Waiting for database to be ready..."
sleep 15

# Run EF migrations
echo "Applying database migrations..."
dotnet ef database update --no-build --project ./MLP10/MLP10.csproj --context YourDbContextName

# Start the app
echo "Starting application..."
dotnet MLP10.dll
