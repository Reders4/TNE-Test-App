#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TNETestApp.App/TNETestApp.App.csproj", "TNETestApp.App/"]
COPY ["TNETestApp.Domain/TNETestApp.Domain.csproj", "TNETestApp.Domain/"]
COPY ["TNETestApp.Infrastructure/TNETestApp.Infrastructure.csproj", "TNETestApp.Infrastructure/"]
COPY ["TNETestApp.Services/TNETestApp.Services.csproj", "TNETestApp.Services/"]
RUN dotnet restore "TNETestApp.App/TNETestApp.App.csproj"
COPY . .
WORKDIR "/src/TNETestApp.App"
RUN dotnet build "TNETestApp.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TNETestApp.App.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TNETestApp.App.dll"]