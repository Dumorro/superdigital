FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ContaCorrente.Extrato.API/ContaCorrente.Extrato.API.csproj", "ContaCorrente.Extrato.API/"]
COPY ["ContaCorrente.Extrato.Infra.CacheAdaptador/ContaCorrente.Extrato.Infra.RedisCacheAdaptador.csproj", "ContaCorrente.Extrato.Infra.CacheAdaptador/"]
COPY ["ContaCorrente.Extrato.Dominio/ContaCorrente.Extrato.Dominio.csproj", "ContaCorrente.Extrato.Dominio/"]
COPY ["ContaCorrente.Extrato.Infra.ExtratoRepositorio/ContaCorrente.Extrato.Infra.ExtratoRepositorio.csproj", "ContaCorrente.Extrato.Infra.ExtratoRepositorio/"]
COPY ["ContaCorrente.Extrato.Aplicacao/ContaCorrente.Extrato.Aplicacao.csproj", "ContaCorrente.Extrato.Aplicacao/"]
RUN dotnet restore "ContaCorrente.Extrato.API/ContaCorrente.Extrato.API.csproj"
COPY . .
WORKDIR "/src/ContaCorrente.Extrato.API"
RUN dotnet build "ContaCorrente.Extrato.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContaCorrente.Extrato.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContaCorrente.Extrato.API.dll"]