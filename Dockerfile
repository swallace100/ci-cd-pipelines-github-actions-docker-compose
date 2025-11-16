# === Build stage ===
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layer
COPY app/src/*.csproj ./
RUN dotnet restore

# Copy the rest of the source
COPY app/src/. .

# Publish the app
RUN dotnet publish -c Release -o /app/publish

# === Runtime stage ===
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Copy published output
COPY --from=build /app/publish .

# App will listen on 8080 inside the container
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Match the DLL name to your project (MyCiCdApp.csproj -> MyCiCdApp.dll)
ENTRYPOINT ["dotnet", "MyCiCdApp.dll"]
