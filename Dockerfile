FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar os arquivos do projeto e restaurar dependências
COPY . ./
RUN dotnet restore

# Buildar a aplicação
RUN dotnet publish -c Release -o /publish

EXPOSE 5000

# Configurar o comando de inicialização
ENTRYPOINT ["dotnet run", "CaitlynsLedgerAPI.dll"]