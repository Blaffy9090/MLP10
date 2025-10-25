#!/bin/bash
set -e

echo "Waiting for database to be ready..."
sleep 100  # wait for SQL Server to start

echo "Applying Entity Framework migrations..."
dotnet-ef database update --no-build --project ./MLP10/MLP10.csproj || echo "Migration failed or already applied."

echo "Starting MLP10 application..."
dotnet MLP10.dll
