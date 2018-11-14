FROM mcr.microsoft.com/mssql/server:2017-latest

ENV ACCEPT_EULA Y
ENV sa_password Samtron@1

RUN apt-get update && apt-get install -y dos2unix

# Create app directory
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app
COPY DB-Scripts /usr/src/app

RUN dos2unix entrypoint.sh
RUN dos2unix import-data.sh

RUN apt-get --purge remove -y dos2unix && rm -rf /var/lib/apt/lists/*

# Grant permissions for the import-data script to be executable
RUN chmod +x /usr/src/app/import-data.sh

CMD /bin/bash ./entrypoint.sh