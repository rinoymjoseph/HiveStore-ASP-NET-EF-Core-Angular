#wait for the SQL Server to come up
echo 'Please wait while SQL Server 2017 warms up'
sleep 60s
#run the setup script to create the DB and the schema in the DB
echo 'Entering => Executing DB Scripts'
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Samtron@1 -d master -i hive_db_create.sql
echo 'Exiting => Executing DB Scripts'