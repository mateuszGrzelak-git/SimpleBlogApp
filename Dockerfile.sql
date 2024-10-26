# SQL Server base image
FROM mcr.microsoft.com/azure-sql-edge:latest

USER root
RUN mkdir -p /usr/src/app
COPY setup.sql /usr/src/app/setup.sql
RUN chmod -R 755 /usr/src/app

EXPOSE 1433
USER mssql
CMD /bin/sh -c "/opt/mssql/bin/sqlservr & sleep 30s & /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P \$SA_PASSWORD -d master -i /usr/src/app/setup.sql"
