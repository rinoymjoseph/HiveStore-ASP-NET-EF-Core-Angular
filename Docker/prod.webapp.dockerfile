FROM microsoft/dotnet:sdk as build-env
WORKDIR /app

# Setup node
ENV NODE_VERSION 8.9.4
ENV NODE_DOWNLOAD_SHA 21fb4690e349f82d708ae766def01d7fec1b085ce1f5ab30d9bda8ee126ca8fc

RUN curl -SL "https://nodejs.org/dist/v${NODE_VERSION}/node-v${NODE_VERSION}-linux-x64.tar.gz" --output nodejs.tar.gz \
    && echo "$NODE_DOWNLOAD_SHA nodejs.tar.gz" | sha256sum -c - \
    && tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \
    && rm nodejs.tar.gz \
    && ln -s /usr/local/bin/node /usr/local/bin/nodejs

# Copy csproj files of each project
COPY HiveStore.DTO/HiveStore.DTO.csproj HiveStore.DTO/
COPY HiveStore.Entity/HiveStore.Entity.csproj HiveStore.Entity/
COPY HiveStore.DataAccess/HiveStore.DataContext.csproj HiveStore.DataAccess/
COPY HiveStore.IHelper/HiveStore.IHelper.csproj HiveStore.IHelper/
COPY HiveStore.Helper/HiveStore.Helper.csproj HiveStore.Helper/
COPY HiveStore.IRepository/HiveStore.IRepository.csproj HiveStore.IRepository/
COPY HiveStore.Repository/HiveStore.Repository.csproj HiveStore.Repository/
COPY HiveStore.IService/HiveStore.IService.csproj HiveStore.IService/
COPY HiveStore.Service/HiveStore.Service.csproj HiveStore.Service/
COPY HiveStore.DI/HiveStore.DI.csproj HiveStore.DI/
COPY HiveStore.WebApp/HiveStore.WebApp.csproj HiveStore.WebApp/

# Run dotnet restore on HiveStore.WebApp project file
RUN dotnet restore HiveStore.WebApp/HiveStore.WebApp.csproj

# Copy package.json file from ClientApp
COPY HiveStore.WebApp/ClientApp/package.json HiveStore.WebApp/ClientApp/

# Change work directory to client app
WORKDIR /app/HiveStore.WebApp/ClientApp

# Run npm install
RUN npm install

# Change the work directory to app
WORKDIR /app

# Copy all files to app directory
COPY . .

# Replace appsettings.json with prod version
COPY HiveStore.WebApp/appsettings.prod.json HiveStore.WebApp/appsettings.json

# Change work directory to HiveStore.WebApp
WORKDIR /app/HiveStore.WebApp

# Publish the release version
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/HiveStore.WebApp/out .
ENV ASPNETCORE_URLS=http://*:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "HiveStore.WebApp.dll"]