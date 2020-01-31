#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ContaCorrente.Extrato.Processadores/ContaCorrente.Extrato.Processadores.csproj", "ContaCorrente.Extrato.Processadores/"]
RUN dotnet restore "ContaCorrente.Extrato.Processadores/ContaCorrente.Extrato.Processadores.csproj"
COPY . .
WORKDIR "/src/ContaCorrente.Extrato.Processadores"
RUN dotnet build "ContaCorrente.Extrato.Processadores.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContaCorrente.Extrato.Processadores.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContaCorrente.Extrato.Processadores.dll"]