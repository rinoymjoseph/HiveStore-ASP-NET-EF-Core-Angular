FROM microsoft/dotnet:sdk as build-env
WORKDIR /app

#setup node
ENV NODE_VERSION 8.9.4
ENV NODE_DOWNLOAD_SHA 21fb4690e349f82d708ae766def01d7fec1b085ce1f5ab30d9bda8ee126ca8fc

RUN curl -SL "https://nodejs.org/dist/v${NODE_VERSION}/node-v${NODE_VERSION}-linux-x64.tar.gz" --output nodejs.tar.gz \
    && echo "$NODE_DOWNLOAD_SHA nodejs.tar.gz" | sha256sum -c - \
    && tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \
    && rm nodejs.tar.gz \
    && ln -s /usr/local/bin/node /usr/local/bin/nodejs

COPY HiveStore.DTO/HiveStore.DTO.csproj HiveStore.DTO/
COPY HiveStore.Entity/HiveStore.Entity.csproj HiveStore.Entity/
COPY HiveStore.DataAccess/HiveStore.DataContext.csproj HiveStore.DataAccess/
COPY HiveStore.IRepository/HiveStore.IRepository.csproj HiveStore.IRepository/
COPY HiveStore.Repository/HiveStore.Repository.csproj HiveStore.Repository/
COPY HiveStore.IService/HiveStore.IService.csproj HiveStore.IService/
COPY HiveStore.Service/HiveStore.Service.csproj HiveStore.Service/
COPY HiveStore.DI/HiveStore.DI.csproj HiveStore.DI/
COPY HiveStore.WebApp/HiveStore.WebApp.csproj HiveStore.WebApp/
RUN dotnet restore HiveStore.WebApp/HiveStore.WebApp.csproj

COPY . .

WORKDIR /app/HiveStore.WebApp
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/HiveStore.WebApp/out .
ENV ASPNETCORE_URLS=http://*:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "HiveStore.WebApp.dll"]