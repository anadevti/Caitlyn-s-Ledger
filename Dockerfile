FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar os arquivos do projeto e restaurar dependências
COPY . ./
RUN dotnet restore

# Buildar a aplicação
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar os arquivos publicados para o container
COPY --from=build /publish .

EXPOSE 8000

# Configurar o comando de inicialização
ENTRYPOINT ["dotnet", "CaitlynsLedgerAPI.dll"]