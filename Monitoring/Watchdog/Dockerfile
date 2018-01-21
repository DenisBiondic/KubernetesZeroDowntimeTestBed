FROM microsoft/dotnet:2.0.5-sdk-2.1.4 as build

ADD Watchdog.csproj /sources/Watchdog.csproj
WORKDIR /sources
RUN dotnet restore

COPY . /sources
RUN dotnet publish -c release --output /app

FROM microsoft/dotnet:2.0.5-runtime
COPY --from=build /app /app
WORKDIR /app
ENTRYPOINT ["dotnet", "Watchdog.dll"]