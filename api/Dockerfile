# Usar uma imagem base do SDK do .NET para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Define o diretório de trabalho
WORKDIR /app

# Copia o arquivo .csproj e restaura as dependências
COPY ./api.csproj ./
RUN dotnet restore

# Copia o restante dos arquivos da aplicação
COPY . ./

# Compila a aplicação, especificando o arquivo do projeto
RUN dotnet publish api.csproj -c Release -o out

# Usar uma imagem base do runtime do .NET para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Define o diretório de trabalho
WORKDIR /app

# Copia os arquivos compilados da etapa de build
COPY --from=build /app/out .

# Expõe a porta da aplicação
EXPOSE 8080

# Define o comando para rodar a aplicação
ENTRYPOINT ["dotnet", "api.dll"]
