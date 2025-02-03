# Anv�nd officiell .NET 8 runtime som bas
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Kopiera �ver projektets publicerade filer
COPY ./publish .

# Exponera porten f�r applikationen
EXPOSE 8080

# Starta applikationen
ENTRYPOINT ["dotnet", "KrypteringApi.dll"]
