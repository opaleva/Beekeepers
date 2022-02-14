﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Notifications/Notifications.csproj", "Notifications/"]
RUN dotnet restore "Notifications/Notifications.csproj"
COPY . .
WORKDIR "/src/Notifications"
RUN dotnet build "Notifications.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notifications.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notifications.dll"]
