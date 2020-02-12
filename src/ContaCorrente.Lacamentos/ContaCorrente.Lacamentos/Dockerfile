FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ContaCorrente.Lacamentos/ContaCorrente.Lacamentos.Api.csproj", "ContaCorrente.Lacamentos/"]
COPY ["ContaCorrente.Lacamentos.Aplicacao/ContaCorrente.Lacamentos.Aplicacao.csproj", "ContaCorrente.Lacamentos.Aplicacao/"]
COPY ["ContaCorrente.Lacamentos.Dominio/ContaCorrente.Lacamentos.Dominio.csproj", "ContaCorrente.Lacamentos.Dominio/"]
COPY ["ContaCorrente.Lacamentos.Infra.MensageriaAdaptador/ContaCorrente.Lacamentos.Infra.Mensageria.csproj", "ContaCorrente.Lacamentos.Infra.MensageriaAdaptador/"]
RUN dotnet restore "ContaCorrente.Lacamentos/ContaCorrente.Lacamentos.Api.csproj"
COPY . .
WORKDIR "/src/ContaCorrente.Lacamentos"
RUN dotnet build "ContaCorrente.Lacamentos.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContaCorrente.Lacamentos.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContaCorrente.Lacamentos.Api.dll"]