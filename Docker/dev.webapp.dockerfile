FROM microsoft/dotnet
LABEL author="Rinoy Joseph"
ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV ASPNETCORE_URLS=http://*:5000
WORKDIR /app/HiveStore.WebApp
CMD ["/bin/bash", "-c", "dotnet restore && dotnet watch run"]
#CMD ["/bin/bash"]