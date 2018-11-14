FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
#COPY HiveStore.WebApp/HiveStore.WebApp.csproj HiveStore.WebApp/
#COPY HiveStore.DTO/HiveStore.DTO.csproj HiveStore.DTO/
#COPY HiveStore.IService/HiveStore.IService.csproj HiveStore.IService/
#COPY HiveStore.Entity/HiveStore.Entity.csproj HiveStore.Entity/
#COPY HiveStore.Helper/HiveStore.DI.csproj HiveStore.Helper/
#COPY HiveStore.Service/HiveStore.Service.csproj HiveStore.Service/
#COPY HiveStore.DataAccess/HiveStore.DataContext.csproj HiveStore.DataAccess/
#COPY HiveStore.IRepository/HiveStore.IRepository.csproj HiveStore.IRepository/
#COPY HiveStore.Repository/HiveStore.Repository.csproj HiveStore.Repository/
#RUN dotnet restore HiveStore.WebApp/HiveStore.WebApp.csproj
#COPY . .
COPY ../. .
WORKDIR /src/HiveStore.WebApp
RUN dotnet restore HiveStore.WebApp/HiveStore.WebApp.csproj

FROM build AS publish
RUN dotnet publish HiveStore.WebApp.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HiveStore.WebApp.dll"]
