FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY MLP10.sln ./
COPY MLP10/MLP10.csproj ./MLP10/

RUN dotnet restore MLP10.sln

COPY . .

RUN dotnet publish MLP10.sln -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime
WORKDIR /app

COPY --from=build /app ./

RUN apk update && apk add --no-cache bash wget unzip \
    && wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh \
    && bash dotnet-install.sh --install-dir /usr/share/dotnet \
    && rm dotnet-install.sh \
    && export PATH="$PATH:/usr/share/dotnet" \
    && dotnet tool install --global dotnet-ef --version 8.* \
    && ln -s /root/.dotnet/tools/dotnet-ef /usr/bin/dotnet-ef \
    && dotnet-ef --version # Verify installation

# Copy startup script
COPY entrypoint.sh /app/
RUN chmod +x /app/entrypoint.sh

# Expose web port
EXPOSE 80

# Start script
ENTRYPOINT ["/app/entrypoint.sh"]
