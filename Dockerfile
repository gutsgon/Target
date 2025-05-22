# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar solução e projetos
COPY ./Target.sln ./
COPY ./Target/*.csproj ./Target/

# Restaurar dependências
RUN dotnet restore

# Copiar todo o restante do código
COPY . .

# Publicar aplicação
WORKDIR /src/Target
RUN dotnet publish -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 5068
ENTRYPOINT ["dotnet", "Target.dll"]
