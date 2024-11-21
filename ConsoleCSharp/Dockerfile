# Alap image a .NET runtime-hoz
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

# Alap image a buildhez
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet build "ConsoleCSharp.csproj" -c Release -o /app/build

# Publikálás
FROM build AS publish
RUN dotnet publish "ConsoleCSharp.csproj" -c Release -o /app/publish

# Runtime image a futtatáshoz
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleCSharp.dll"]
