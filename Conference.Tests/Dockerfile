FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Notifications.Tests/Notifications.Tests.csproj", "Notifications.Tests/"]
RUN dotnet restore "Notifications.Tests/Notifications.Tests.csproj"
COPY . .
WORKDIR "/src/Notifications.Tests"
RUN dotnet build "Notifications.Tests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notifications.Tests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notifications.Tests.dll"]
