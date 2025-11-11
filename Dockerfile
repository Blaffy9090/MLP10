FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution file
COPY MLP10.sln ./

# Copy project files
COPY MLP10/MLP10.csproj ./MLP10/
COPY MLP10.Tests/MLP10.Tests.csproj ./MLP10.Tests/

# Restore dependencies
RUN dotnet restore MLP10.sln

# Copy remaining source code
COPY . .

# Build the solution
RUN dotnet build MLP10.sln -c Release --no-restore

# Publish the project (tests will run in CI, not in Docker build)
RUN dotnet publish MLP10/MLP10.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS runtime
WORKDIR /app

COPY --from=build /app ./

# Install necessary tools
RUN apk update && apk add --no-cache bash wget unzip \
    && wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh \
    && bash dotnet-install.sh --install-dir /usr/share/dotnet \
    && rm dotnet-install.sh \
    && dotnet tool install --global dotnet-ef --version 8.* \
    && ln -s /root/.dotnet/tools/dotnet-ef /usr/bin/dotnet-ef

# Copy startup script
COPY entrypoint.sh /app/
RUN chmod +x /app/entrypoint.sh

# Expose web port
EXPOSE 80

# Start script
ENTRYPOINT ["/app/entrypoint.sh"]