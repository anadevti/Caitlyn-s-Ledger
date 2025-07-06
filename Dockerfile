FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia o arquivo de projeto e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copia todo o resto do código e constrói a aplicação
COPY . ./
RUN dotnet publish -c Release -o out

# Imagem final de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expõe a porta que a aplicação usa
EXPOSE 8080

ENTRYPOINT ["dotnet", "CaitlynsLedgerAPI.dll"] 