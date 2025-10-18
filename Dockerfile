# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files first (better layer caching)
COPY MLP10.sln ./
COPY MLP10/MLP10.csproj ./MLP10/

# Restore dependencies
RUN dotnet restore MLP10.sln

# Copy the rest of the source
COPY . .

# Publish the app to /app
RUN dotnet publish MLP10.sln -c Release -o /app

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app ./

# Expose port 80 (HTTP)
EXPOSE 80

COPY entrypoint.sh /app/
RUN chmod +x /app/entrypoint.sh

ENTRYPOINT ["/app/entrypoint.sh"]
