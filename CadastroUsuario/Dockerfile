
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore 
RUN dotnet build --no-restore -c Release -o /app
ENV ASPNETCORE_URLS http://*:44319

ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 44319

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CadastroUsuario.dll"]
