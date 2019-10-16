FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 44371
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["TemperatureApi/TemperatureApi.csproj", "TemperatureApi/"]
RUN dotnet restore "TemperatureApi/TemperatureApi.csproj"
COPY . .
WORKDIR "/src/TemperatureApi"
RUN dotnet build "TemperatureApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TemperatureApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TemperatureApi.dll"]