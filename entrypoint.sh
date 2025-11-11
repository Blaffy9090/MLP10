#!/bin/bash
set -e

echo "Waiting for database to be ready..."

# More robust database connection check
for i in {1..30}; do
    if curl -s --head --request GET http://db:1433 | grep "200" > /dev/null; then
        echo "Database is ready!"
        break
    else
        echo "Waiting for database... Attempt $i/30"
        sleep 10
    fi
done

echo "Applying Entity Framework migrations..."
dotnet-ef database update --no-build --project ./MLP10/MLP10.csproj --verbose

echo "Starting MLP10 application..."
dotnet MLP10.dll