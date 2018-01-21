FROM microsoft/aspnetcore-build:2.0.2 as build

ADD FancyService.csproj /sources/FancyService.csproj
WORKDIR /sources
RUN dotnet restore

COPY . /sources
RUN dotnet publish -c release --output /app

FROM microsoft/aspnetcore:2.0.0
COPY --from=build /app /app
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "FancyService.dll"]