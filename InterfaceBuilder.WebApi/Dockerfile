FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS http://+:50000
EXPOSE 50000

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY InterfaceBuilder.WebApi/InterfaceBuilder.WebApi.csproj InterfaceBuilder.WebApi/
RUN dotnet restore
COPY . .
WORKDIR /src/InterfaceBuilder.WebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "InterfaceBuilder.WebApi.dll"]
