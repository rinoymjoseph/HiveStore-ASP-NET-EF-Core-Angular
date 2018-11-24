# HiveStore-ASP-NET-EF-Core-Angular

1) You need Visual Studio 2017 to run this application.

2) Please refer below link to understand more about application architecture and db structure.

    http://hive.rinoy.in/building-a-web-app-using-asp-net-core-2-and-angular5-frameworks/

3) Execute the script 'hive_db_create.sql' in DB-Scripts folder to create Schema and Tables.

4) Replace the connection string in ConnectionStrings section in appsettings.json in HiveStoreNGCoreApp.Web project

The application is ready to run.

Docker
-------
C:\projects\github\HiveStore-ASP-NET-EF-Core-Angular> docker-compose -f .\Docker\prod-lb.docker-compose.yml build
docker-compose -f .\Docker\prod-lb.docker-compose.yml build
docker-compose -f .\Docker\prod-lb.docker-compose.yml up
docker-compose -f .\Docker\prod-lb.docker-compose.yml down