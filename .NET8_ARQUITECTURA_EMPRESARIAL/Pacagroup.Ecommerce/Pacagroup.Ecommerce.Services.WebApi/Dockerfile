# Etapa de build (SDK .NET 8)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src

# Copia todo el código (mismo comportamiento que tu Dockerfile original)
COPY . .

# Restaura y publica el proyecto WebApi
WORKDIR /src/Pacagroup.Ecommerce.Services.WebApi
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Etapa final (ASP.NET Core Runtime .NET 8)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Copia lo publicado
COPY --from=build-env /app/publish .

# Punto de entrada
ENTRYPOINT ["dotnet", "Pacagroup.Ecommerce.Services.WebApi.dll"]
