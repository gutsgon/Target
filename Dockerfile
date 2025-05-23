# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar arquivos do projeto e restaurar pacotes
COPY Target.sln ./
COPY Target.csproj ./
RUN dotnet restore

# Copiar arquivos restantes do projeto
COPY . ./

# Publicar o projeto
RUN dotnet publish -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 5068
ENTRYPOINT ["dotnet", "Target.dll"]
