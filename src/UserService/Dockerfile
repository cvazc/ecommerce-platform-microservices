# Etapa 1: Compilación de la aplicación
# Usamos la imagen del SDK de .NET 9 (o la versión que estés usando)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

# Copiar los archivos .csproj y restaurar dependencias
# Copia el archivo .csproj específico del UserService
COPY UserService.csproj ./
RUN dotnet restore

# Copiar el resto del código fuente y compilar
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Construcción de la imagen final de ejecución
# Usamos la imagen de runtime de ASP.NET Core 9 (o la versión correspondiente)
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/out .

# El ENTRYPOINT ahora usa UserService.dll
ENTRYPOINT ["dotnet", "UserService.dll"]