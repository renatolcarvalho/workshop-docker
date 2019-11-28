FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Example.WebApi/Example.WebApi.csproj", "Example.WebApi/"]
COPY ["Example.Infra.IoC/Example.Infra.IoC.csproj", "Example.Infra.IoC/"]
COPY ["Example.Infra.Repository/Example.Infra.Repository.csproj", "Example.Infra.Repository/"]
COPY ["Example.Domain/Example.Domain.csproj", "Example.Domain/"]
COPY ["Example.Application/Example.Application.csproj", "Example.Application/"]
RUN dotnet restore "Example.WebApi/Example.WebApi.csproj"
COPY . .
WORKDIR "/src/Example.WebApi"
RUN dotnet build "Example.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Example.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.WebApi.dll"]
