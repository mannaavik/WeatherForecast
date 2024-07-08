FROM mcr.microsoft.com/dotnet/asp.net:7.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WeatherService/WeatherService.csproj", "WeatherService/"]
COPY ["WeatherApplication/WeatherApplication.csproj", "WeatherApplication/"]
COPY ["WeatherInfrastructure/WeatherInfrastructure.csproj", "WeatherInfrastructure/"]
COPY ["WeatherDomain/WeatherService.csproj", "WeatherDomain.csproj/"]
RUN dotnet restore "WeatherService/WeatherService.csproj"
COPY . .
WORKDIR "/src/WeatherService"
RUN dotnet build "WeatherService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build as publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WeatherService.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "WeatherService.dll" ]